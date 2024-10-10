using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherDeath : State
{
    public GameObject deathEffect;
    public override void OnStart()
    {
        Debug.Log("Goblin Dead");
        Destroy(transform.parent.parent.gameObject);
        var d = Instantiate(deathEffect, transform.position, Quaternion.identity);
        d.GetComponent
    }

    public override void OnUpdate(){}

    public override void OnLateUpdate(){}

    public override void OnExit(){}
}
