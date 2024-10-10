using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossHit : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossRunaway goblinFleeState; // state

    public override void OnUpdate(){}

    public override void OnStart()
    {
        Debug.Log("Boss is hit");
    }
    public override void OnLateUpdate(){}
    public override void OnExit(){}
}
