using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossShoot : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state
    [SerializeField] private GoblinBossStun goblinStunState; // state

    public override void OnUpdate(){}

    public override void OnStart(){}
    public override void OnLateUpdate(){}
    public override void OnExit(){}
}
