using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSwordJump : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordChase swordChaseState; // state
    public override void OnStart()
    {
        //Jump into the air
        //Move towards the player
        //
    }

    public override void OnUpdate(){}

    public override void OnLateUpdate(){}

    public override void OnExit(){}
}
