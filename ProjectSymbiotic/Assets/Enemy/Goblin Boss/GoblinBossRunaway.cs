using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinBossRunaway : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state
    [SerializeField] private GoblinBossEnraged goblinEnragedState; // state
    [SerializeField] private GoblinBossStun goblinStunState; // state
    [SerializeField] private float speed;
    private Transform target;
    [SerializeField] private GameObject player1;
    private int numStags;

    public override void OnUpdate()
    {
        numStags = StalagManager.numStags;
        if(numStags == 0)
        {
            stateMachine.setNewState(goblinEnragedState);
        }
        if(StalagManager.gobHit)
        {
            stateMachine.setNewState(goblinStunState);
        }
    }

    public override void OnStart()
    {
        enemyBase.canBeHurt = false;
        Debug.Log("Boss is running");
        target = player1.transform;
        StartCoroutine(RunAwayTime());
    }
    public override void OnLateUpdate()
    {
        enemyBase.transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);
    }
    public override void OnExit(){}

    private IEnumerator RunAwayTime()
    {
        yield return new WaitForSeconds(3);
        stateMachine.setNewState(goblinChargeState);
    }
}
