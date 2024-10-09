using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSwordStun : State
{
    [SerializeField] Enemy enemyBase;
    [SerializeField] private GoblinSwordChase swordChaseState; // state
    public int stunTimer;
    
    public override void OnStart()
    {
        //be still for a few seconds and then return to chase
        StartCoroutine(Stunned());
    }

    public override void OnUpdate(){}

    public override void OnLateUpdate(){}

    public override void OnExit(){}

    IEnumerator Stunned()
    {
        yield return new WaitForSeconds(stunTimer);
        stateMachine.setNewState(swordChaseState);
    }
}
