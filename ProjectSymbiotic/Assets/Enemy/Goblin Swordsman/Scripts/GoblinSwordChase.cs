using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class GoblinSwordChase : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordJump goblinJumpState; // state
    [SerializeField] private GoblinSwordStun stunState; // state

    private Transform target;
    [SerializeField] private float speed;
    private float distance;
    [SerializeField] private GoblinSwordAttack goblinAttackState; // state

    public override void OnStart()
    {
        Debug.Log("Chase Start");
        stateMachine.animator.SetBool("isWalking", true);
        target = enemyBase.target;
    }

    public override void OnUpdate()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if(enemyBase.isHitObject && !enemyBase.isHitPlayer)
        {
            stateMachine.setNewState(goblinJumpState);
        }
        if(enemyBase.isHitPlayer)
        {
            stateMachine.setNewState(goblinAttackState);
        }
    }

    public override void OnLateUpdate()
    {
        if(distance > 0.1f)
        {
            enemyBase.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }

    public override void OnExit()
    {
        stateMachine.animator.SetBool("isWalking", false);
    }
}
