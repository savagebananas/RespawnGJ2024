using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherIdle : State
{
    public float shootingCooldown = 3.0f;
    private float timer;

    public State goblinShootState;

    public override void OnStart()
    {
        timer = shootingCooldown;
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stateMachineManager.setNewState(goblinShootState);
        }
    }

    public override void OnLateUpdate(){}
}
