using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinBossShoot : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state
    [SerializeField] private GoblinBossStun goblinStunState; // state
    [SerializeField] private GameObject player2;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject chainShot;
    [SerializeField] private GoblinBossEnraged goblinEnragedState; // state
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
        Instantiate(chainShot, this.transform.position, this.transform.rotation);
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
