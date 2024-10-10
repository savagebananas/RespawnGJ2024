using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If wait till next shot is ready. If goblin is too far away, stop shooting (Go to idle).
/// </summary>
public class GoblinArcherCooldown : State
{
    [SerializeField] Enemy enemyBase;
    [SerializeField] Transform target;

    public static float shootingCooldown = 1.0f;
    private float timer;

    public State goblinPrepareShot;
    public State goblinIdle;

    public override void OnStart()
    {
        timer = shootingCooldown;
        var height = transform.position.y;
        target = enemyBase.target;
        var targetHeight = target.position.y;
        if (height - targetHeight > 8 || height < -2)
        {
            stateMachine.setNewState(goblinIdle);
        }
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            stateMachine.setNewState(goblinPrepareShot);
        }
    }

    public override void OnLateUpdate() { }

    public override void OnExit()
    {
        return;
    }
}
