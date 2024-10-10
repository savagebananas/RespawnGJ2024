using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossCharge : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossShoot goblinShootState; // state
    [SerializeField] private GoblinBossStun goblinStunState; // state
    [SerializeField] private GoblinBossEnraged goblinEnragedState; // state
    private Transform target;
    [SerializeField] private float speed;
    private float distance;
    private float height;
    private float targetHeight;
    [SerializeField] private GameObject player1;
    private int numStags;

    public override void OnStart()
    {
        enemyBase.canBeHurt = false;
        Debug.Log("Boss is charging");
        target = player1.transform;
    }

    public override void OnUpdate()
    {
        numStags = StalagManager.numStags;

        distance = Vector2.Distance(transform.position, target.position);

        height = transform.position.y;
        targetHeight = enemyBase.target.position.y;

        //numStags = stags.getnum
        if(numStags == 0)
        {
            stateMachine.setNewState(goblinEnragedState);
        }
        if(StalagManager.gobHit)
        {
            stateMachine.setNewState(goblinStunState);
        }
    }

    public override void OnLateUpdate()
    {
        if(distance > 0.1f)
        {
            enemyBase.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (height - targetHeight >= 5)
        {
            //Start cutscene
            //Somehow determine if cutscene is done
            stateMachine.setNewState(goblinShootState);
        }
        
    }
    public override void OnExit(){}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<PlayerMovement>() != null)
        {
            col.gameObject.GetComponent<PlayerMovement>().TakeDamage(1);
            stateMachine.setNewState(goblinShootState);
        }

        if(col.gameObject.GetComponent<Player2Movement>() != null)
        {
            col.gameObject.GetComponent<Player2Movement>().TakeDamage(1);
            stateMachine.setNewState(this);
        }

        if(col.gameObject.tag == "Stalag")
        {
            stateMachine.setNewState(goblinStunState);
        }
    }
}
