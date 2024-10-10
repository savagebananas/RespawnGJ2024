using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossCharge : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossShoot goblinShootState; // state
    [SerializeField] private GoblinBossStun goblinStunState; // state

    public override void OnUpdate(){}

    public override void OnStart()
    {
        Debug.Log("Boss is charging");
    }
    public override void OnLateUpdate(){}
    public override void OnExit(){}
}
