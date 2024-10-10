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
        var distance = transform.position.y;
        var targetdistance = enemyBase.target.position.x;
        if (distance - targetdistance <= 5 && distance >= -2)
        {
            //Start cutscene
            //Somehow determine if cutscene is done
            stateMachine.setNewState(goblinChargeState);
        }
    }

    public override void OnStart()
    {
        Debug.Log("Boss is idle");
    }
    public override void OnLateUpdate(){}
    public override void OnExit(){}
}
