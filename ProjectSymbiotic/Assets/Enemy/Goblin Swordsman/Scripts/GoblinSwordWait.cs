using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinSwordWait : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordJump goblinJumpState; // state
    

    public override void OnUpdate()
    {
        // When player is within distance, start shooting again
        var height = transform.position.y;
        var targetHeight = enemyBase.target.position.y;
        if (height - targetHeight <= 5 && height >= -2)
        {
            stateMachine.setNewState(goblinJumpState);
        }
    }

    public override void OnStart()
    {
        //Debug.Log("Wait Start");
    }
    public override void OnLateUpdate(){}
    public override void OnExit(){}

    
}
