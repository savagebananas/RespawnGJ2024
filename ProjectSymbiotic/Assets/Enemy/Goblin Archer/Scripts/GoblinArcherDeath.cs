using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherDeath : State
{
    public override void OnStart()
    {
        Debug.Log("Goblin Dead");
        GameObject.Destroy(transform.parent.parent.gameObject);
    }

    public override void OnUpdate(){}

    public override void OnLateUpdate(){}

    public override void OnExit(){}
}
