using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdle : State
{
    [SerializeField] Enemy enemyBase;
    [SerializeField] State goblinChargeShot;

    public override void OnUpdate()
    {
        // When player is within distance, start shooting again
        var height = transform.position.y;
        var targetHeight = enemyBase.target.position.y;
        if (height - targetHeight <= 8 && height >= -2)
        {
            stateMachine.setNewState(goblinChargeShot);
        }
    }

    public override void OnStart() { }

    public override void OnExit(){}

    public override void OnLateUpdate(){}

}
