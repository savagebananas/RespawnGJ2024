using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int difficulty = 1;

    private Transform p1;
    private Transform p2;
    public Transform target;
    public bool aimLeft;

    [SerializeField] private float health = 1;

    [SerializeField] private StateMachineManager stateMachine;
    [SerializeField] State hurtState;
    [SerializeField] State deathState;

    private void Start()
    {
        p1 = GameObject.Find("Player1").transform;
        p2 = GameObject.Find("Player2").transform;
    }

    private void Update()
    {
        SetClosestTarget();
        Visuals();
    }

    public void TakeDamage(float dmg)
    {
        Debug.Log("Take DMG");
        health -= dmg;
        if (health <= 0 && deathState != null) stateMachine.setNewState(deathState);
        else stateMachine.setNewState(hurtState);
    }


    private void SetClosestTarget()
    {
        if (p1 != null && p2 == null) target = p1;
        else if (p2 != null && p1 == null) target = p2;
        else if (Vector2.Distance(transform.position, p1.position) >= Vector2.Distance(transform.position, p2.position)) target = p1;
        else target = p2;
    }

    private void Visuals()
    {
        if (target.position.x <= transform.position.x)
        {
            transform.localScale = Vector3.one;
            aimLeft = true;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            aimLeft = false;
        }
    }
}
