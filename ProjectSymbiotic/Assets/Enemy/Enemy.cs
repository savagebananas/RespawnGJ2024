using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 1;

    [SerializeField] private StateMachineManager stateMachine;
    [SerializeField] State hurtState;
    [SerializeField] State deathState;

    public void TakeDamage(float dmg)
    {
        Debug.Log("Take DMG");
        health -= dmg;
        if (health <= 0 && deathState != null) stateMachine.setNewState(deathState);
        else stateMachine.setNewState(hurtState);
    }
}
