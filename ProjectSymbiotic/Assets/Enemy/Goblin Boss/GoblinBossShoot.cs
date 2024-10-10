using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinBossShoot : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state
    [SerializeField] private GoblinBossStun goblinStunState; // state
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject chainShot;
    [SerializeField] private GoblinBossEnraged goblinEnragedState; // state
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] float p1distance;
    [SerializeField] float p2distance;
    private int numStags;

    public override void OnUpdate()
    {
        numStags = StalagManager.numStags;

        if(chainShot.GetComponent<ChainShot>().hasReturned)
        {
            Player2Movement p2mv = player2.GetComponent<Player2Movement>();
            p2mv.enabled = true;
            stateMachine.setNewState(goblinChargeState);
        }

        //numStags = stags.getnum
        if(numStags == 0)
        {
            stateMachine.setNewState(goblinEnragedState);
        }
        if(StalagManager.gobHit)
        {
            stateMachine.setNewState(goblinStunState);
        }

        float p1Xdistance = math.abs(enemyBase.transform.position.x - player1.transform.position.x);
        float p1Ydistance = math.abs(enemyBase.transform.position.y - player1.transform.position.y);
        p1distance = p1Xdistance + p1Ydistance;
        if(p1distance < 2)
        {
            player1.gameObject.GetComponent<PlayerMovement>().TakeDamage(1);
            stateMachine.setNewState(this);
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

    public override void OnStart()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        enemyBase.canBeHurt = false;
        Debug.Log("Boss is shooting");
        Shoot();
    }

    private void Shoot()
    {
        Instantiate(chainShot, enemyBase.transform.position, Quaternion.identity);
    }

    public override void OnLateUpdate(){}
    public override void OnExit()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Stalag")
        {
            stateMachine.setNewState(goblinStunState);
        }
    }
}
