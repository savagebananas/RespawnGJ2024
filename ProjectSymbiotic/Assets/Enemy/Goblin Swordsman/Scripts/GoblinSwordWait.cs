using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinSwordWait : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordJump goblinJumpState; // state
    [SerializeField] private GoblinSwordJump goblinAttackState; // state

    public override void OnUpdate()
    {
        Debug.Log("Wait Start");
        // When player is within distance, start shooting again
        var height = transform.position.y;
        var targetHeight = enemyBase.target.position.y;
        if (height - targetHeight <= 5 && height >= -2)
        {
            stateMachine.setNewState(goblinJumpState);
        }
    }

    public override void OnStart(){}
    public override void OnLateUpdate(){}
    public override void OnExit(){}

    void OnCollisionEnter2D(Collision2D col)
    {
        //Crate or rock hit
        if(col.gameObject.layer == 7)
        {
            stateMachine.setNewState(goblinJumpState);
        }
        
        //Player hit
        if(col.gameObject.layer == 3)
        {
            stateMachine.setNewState(goblinAttackState);
        }
    }
}
