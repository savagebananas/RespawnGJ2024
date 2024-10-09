using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class GoblinSwordChase : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordJump goblinJumpState; // state

    private Transform target;
    [SerializeField] private float speed;

    [SerializeField] private GoblinSwordJump goblinAttackState; // state

    public override void OnStart()
    {
        Debug.Log("Chase Start");
        target = enemyBase.target;
    }

    public override void OnUpdate()
    {
        target = enemyBase.target;

        float distance = Vector2.Distance(transform.position, target.position);

        
    }

    public override void OnLateUpdate()
    {
        enemyBase.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

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
