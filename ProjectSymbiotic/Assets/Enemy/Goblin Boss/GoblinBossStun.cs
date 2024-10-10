using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossStun : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossHit goblinHitState; // state
    [SerializeField] private GoblinBossCharge goblinChargeState; // state
    private float startHealth;

    public override void OnUpdate()
    {
        if(enemyBase.health != startHealth)
        {
            stateMachine.setNewState(goblinHitState);
        }
    }

    public override void OnStart()
    {
        startHealth = enemyBase.health;
        enemyBase.canBeHurt = true;
        Debug.Log("Boss is Stunned");

        StartCoroutine(StunTimer());
    }
    public override void OnLateUpdate(){}
    public override void OnExit()
    {
        StopAllCoroutines();
    }

    private IEnumerator StunTimer()
    {
        yield return new WaitForSeconds(5);
        stateMachine.setNewState(goblinChargeState);
    }
}
