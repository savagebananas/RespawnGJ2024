using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossDeath : State
{
    public GameObject deathEffect;
    [SerializeField] CinemachineImpulseSource screenShake;
    [SerializeField] GameManager gameManager;
    [SerializeField] State bossBeatState;

    public override void OnStart()
    {
        Debug.Log("BOSS DEAD!");
        Destroy(transform.parent.parent.gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        screenShake.GenerateImpulse();
        gameManager.setNewState(bossBeatState);
    }

    public override void OnUpdate() { }

    public override void OnLateUpdate() { }

    public override void OnExit() { }
}
