using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossStun : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossHit goblinHitState; // state
    [SerializeField] private GoblinBossCharge goblinChargeState; // state

    public override void OnUpdate(){}

    public override void OnStart()
    {
        Debug.Log("Boss is Stunned");
    }
    public override void OnLateUpdate(){}
    public override void OnExit(){}
}
