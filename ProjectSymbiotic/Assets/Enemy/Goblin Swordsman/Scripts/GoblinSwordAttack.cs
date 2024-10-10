using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSwordAttack : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordChase swordChaseState; // state
    [SerializeField] private GoblinSwordStun stunState; // state

    [SerializeField] private float waitTime;
    [SerializeField] private bool readyToSwing = true;
    private Transform target;
    private float distance;
    public Transform attackPos;
    public float attackRange;
    public LayerMask damageableLayer;
    public int damage;

    public override void OnStart()
    {
        //Debug.Log("Attack Start");
        target = enemyBase.target;
    }

    public override void OnUpdate()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if(distance > 0.5f)
        {
            stateMachine.setNewState(swordChaseState);
        }

        if (readyToSwing)
        {
            readyToSwing = false;
            //Swing at the player
            Collider2D[] damageables = Physics2D.OverlapCircleAll(attackPos.position, attackRange, damageableLayer);
            //if hit do damage to player
            for (int i = 0; i < damageables.Length; i++)
            {
                Debug.Log("Hit");
                if(damageables[i].GetComponent<PlayerMovement>() != null)
                {
                    damageables[i].GetComponent<PlayerMovement>().TakeDamage(damage);
                }
                else if(damageables[i].GetComponent<Player2Movement>() != null)
                {
                    damageables[i].GetComponent<Player2Movement>().TakeDamage(damage);
                }
            }

            StartCoroutine(WaitToSwing());
        }

        if(enemyBase.isHitByRock)
        {
            stateMachine.setNewState(stunState);
        }
    }

    public override void OnLateUpdate(){}

    public override void OnExit(){}

    IEnumerator WaitToSwing()
    {
        yield return new WaitForSeconds(waitTime);
        readyToSwing = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
