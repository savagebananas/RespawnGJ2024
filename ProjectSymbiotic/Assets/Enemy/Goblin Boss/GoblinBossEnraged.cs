using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class GoblinBossEnraged : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] float p1distance;
    [SerializeField] float p2distance;
    
     public override void OnUpdate()
     {
        //Acting as on collide
        float p1Xdistance = math.abs(enemyBase.transform.position.x - player1.transform.position.x);
        float p1Ydistance = math.abs(enemyBase.transform.position.y - player1.transform.position.y);
        p1distance = p1Xdistance + p1Ydistance;
        if(p1distance < 2)
        {
            player1.gameObject.GetComponent<PlayerMovement>().TakeDamage(1);
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
       StartCoroutine(Countdown());
    }
    public override void OnLateUpdate()
    {

    }
    public override void OnExit()
    {
        StalagManager.gobDone = true;
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        stateMachine.setNewState(goblinChargeState);
    }
}
