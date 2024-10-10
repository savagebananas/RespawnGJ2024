using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherDeath : State
{
    public GameObject deathEffect;
    [SerializeField] CinemachineImpulseSource screenShake;
    public override void OnStart()
    {
        Debug.Log("Goblin Dead");
        Destroy(transform.parent.parent.gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        screenShake.GenerateImpulse();
    }

    public override void OnUpdate(){}

    public override void OnLateUpdate(){}

    public override void OnExit(){}
}
