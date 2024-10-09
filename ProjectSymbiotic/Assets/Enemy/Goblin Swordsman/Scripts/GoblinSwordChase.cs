using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSwordChase : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordJump goblinJumpState; // state
    
    public override void OnStart()
    {
        Debug.Log("Chase Start");

    }

    public override void OnUpdate()
    {

    }

    public override void OnLateUpdate(){}

    public override void OnExit(){}
}
