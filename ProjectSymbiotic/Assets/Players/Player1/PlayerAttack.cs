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
        while(isSpecialAttacking)
        {
            //TODO copy everything from attack function
        }

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
            timeBetweenAttack -= Time.deltaTime;
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
                //damageables.GetValueAt(i).GetComponent<PlayerAttack>().Attack(context);
                //damageables.GetValueAt(i).GetComponent<damageable>().TakeDamage(damage)
            }
        }
    }

    public void SpecialAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Special Start");
        isReadyToSpecial = false;
        StartCoroutine(Charge());
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
        this.GetComponent<PlayerMovement>().speed *= 2;
        yield return new WaitForSeconds(chargeTime);

        //TODO Stop animation
        isSpecialAttacking = false;
        this.GetComponent<PlayerMovement>().speed /= 2;
        this.GetComponent<PlayerMovement>().canBeHurt = true;
    }
}
