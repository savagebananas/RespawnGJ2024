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
        enemyBase.canBeHurt = false;
        //Flash red for a second or so
        Debug.Log("Boss is hit");
        StartCoroutine(FlashRed());
    }
    public override void OnLateUpdate(){}
    public override void OnExit(){}

    private IEnumerator FlashRed()
    {
        //flash red in animation
        yield return new WaitForSeconds(1);
        stateMachine.setNewState(goblinFleeState);
    }
}
