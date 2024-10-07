using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherDeath : State
{
    public override void OnStart()
    {
        Debug.Log("Goblin Dead");
    }

    public override void OnUpdate(){}

    public override void OnLateUpdate(){}
}
