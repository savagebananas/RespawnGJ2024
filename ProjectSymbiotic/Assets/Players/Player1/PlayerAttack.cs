using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public bool isReadyToAttack = true;

    private float timeBetweenSpecial;
    public float startTimeBetweenSpecial;
    public bool isReadyToSpecial = true;
    public bool isSpecialAttacking = false;
    public float chargeTime;

    public Transform attackPos;
    public float attackRange;
    public LayerMask damageableLayer;
    public int damage;

    void Update()
    {
        

        if (timeBetweenAttack <= 0)
        {
            timeBetweenAttack = startTimeBetweenAttack;
            isReadyToAttack = true;
        }

        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }

        if (timeBetweenSpecial <= 0)
        {
            timeBetweenSpecial = startTimeBetweenSpecial;
            isReadyToSpecial = true;
        }

        else
        {
            timeBetweenSpecial -= Time.deltaTime;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Start");
        if (context.performed && isReadyToAttack)
        {
            Debug.Log("Swing");
            isReadyToAttack = false;
            Collider2D[] damageables = Physics2D.OverlapCircleAll(attackPos.position, attackRange, damageableLayer);
            for (int i = 0; i < damageables.Length; i++)
            {
                Debug.Log("Hit");
                if(damageables[i].GetComponent<FallingObject>() != null){
                    damageables[i].GetComponent<FallingObject>().TakeDamage(damage);
                }
                else if(damageables[i].GetComponent<Enemy>() != null)
                {
                    damageables[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                
            }
        }
    }

    public void SpecialAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Special Start");
        if(isReadyToSpecial)
        {
            isReadyToSpecial = false;
            StartCoroutine(Charge());
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    IEnumerator Charge()
    {
        //TODO Start animation
        isSpecialAttacking = true;
        this.GetComponent<PlayerMovement>().canBeHurt = false;
        this.GetComponent<PlayerMovement>().speed *= 1.5f;
        yield return new WaitForSeconds(chargeTime);
        Debug.Log("Done timer");

        //TODO Stop animation
        isSpecialAttacking = false;
        this.GetComponent<PlayerMovement>().speed /= 1.5f;
        this.GetComponent<PlayerMovement>().canBeHurt = true;
    }
}
