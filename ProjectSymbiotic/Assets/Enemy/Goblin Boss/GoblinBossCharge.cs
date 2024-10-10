using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    [SerializeField] private GameObject player2;
    private int numStags;

    [SerializeField] float p1distance;
    [SerializeField] float p2distance;

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

        //Acting as on collide
        float p1Xdistance = math.abs(enemyBase.transform.position.x - player1.transform.position.x);
        float p1Ydistance = math.abs(enemyBase.transform.position.y - player1.transform.position.y);
        p1distance = p1Xdistance + p1Ydistance;
        if(p1distance < 2)
        {
            player1.gameObject.GetComponent<PlayerMovement>().TakeDamage(1);
            stateMachine.setNewState(goblinShootState);
        }
        float p2Xdistance = math.abs(enemyBase.transform.position.x - player2.transform.position.x);
        float p2Ydistance = math.abs(enemyBase.transform.position.y - player2.transform.position.y);
        p2distance = p2Xdistance + p2Ydistance;
        if(p2distance < 2)
        {
            player2.gameObject.GetComponent<PlayerMovement>().TakeDamage(1);
            stateMachine.setNewState(this);
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
        if(col.gameObject.tag == "Stalag")
        {
            stateMachine.setNewState(goblinStunState);
        }
    }
}
