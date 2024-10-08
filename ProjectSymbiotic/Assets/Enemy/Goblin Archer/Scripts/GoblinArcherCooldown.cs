using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherCooldown : State
{
    public static float shootingCooldown = 3.0f;
    private float timer;

    public State goblinPrepareShot;

    public override void OnStart()
    {
        timer = shootingCooldown;
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
