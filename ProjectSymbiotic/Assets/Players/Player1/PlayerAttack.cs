using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public bool isReadyToAttack = true;

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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
