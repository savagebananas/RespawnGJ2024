using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossIdle : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state

    public override void OnUpdate()
    {
        
        // When player is within distance, start shooting again
        var distance = transform.position.x;
        var targetdistance = enemyBase.target.position.x;
        if (distance - targetdistance <= 5 )
        {
            //Start cutscene
            //Somehow determine if cutscene is done
            stateMachine.setNewState(goblinChargeState);
        }
    }

    public override void OnStart()
    {
        enemyBase.canBeHurt = false;
        Debug.Log("Boss is idle");
    }
    public override void OnLateUpdate(){}
    public override void OnExit(){}
}
