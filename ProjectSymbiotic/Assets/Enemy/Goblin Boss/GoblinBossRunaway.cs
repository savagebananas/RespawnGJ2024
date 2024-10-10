using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossRunaway : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state

    public override void OnUpdate(){}

    public override void OnStart()
    {
        Debug.Log("Boss is running");
    }
    public override void OnLateUpdate(){}
    public override void OnExit(){}
}
