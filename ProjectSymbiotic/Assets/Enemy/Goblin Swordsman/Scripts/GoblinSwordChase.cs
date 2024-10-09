using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GoblinSwordChase : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordJump goblinJumpState; // state

    private Transform target;
    [SerializeField] private float speed;

    public override void OnStart()
    {
        Debug.Log("Chase Start");

    }

    public override void OnUpdate()
    {
        target = enemyBase.target;

        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public override void OnLateUpdate(){}

    public override void OnExit(){}
}
