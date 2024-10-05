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
    public LayerMask damagableLayer;
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
            isReadyToAttack = false;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && isReadyToAttack)
        {
            Collider2D[] damagables = Physics2D.OverlapCircleAll(attackPos.position, attackRange, damagableLayer);
            for (int i = 0; i < damagables.Length; i++)
            {
                //put something about damage here once destroyables are made
                //damagables.GetComponent<damagable>().health -= damage;
                //or
                //damagables.GetComponent<damagable>().TakeDamage(damage)
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
