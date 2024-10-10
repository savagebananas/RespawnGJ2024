using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GoblinBossEnraged : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state
    
     public override void OnUpdate(){}

    public override void OnStart()
    {
       StartCoroutine(Countdown());
    }
    public override void OnLateUpdate()
    {

    }
    public override void OnExit()
    {
        StalagManager.gobDone = true;
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
    }
}
