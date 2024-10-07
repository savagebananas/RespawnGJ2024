using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinShoot : State
{
    public Transform target;
    public GameObject arrowPrefab;
    public int difficulty = 1;

    private float timeToHit;
    const float GRAVITY = 9.81f;
    private float arrowMass;

    public State idleState; // Timer cooldown for shooting is in goblin idle state
    public State deathState;

    public override void OnStart()
    {
        arrowMass = arrowPrefab.GetComponent<Rigidbody2D>().mass;
        ShootArrow();
        stateMachineManager.setNewState(idleState);
    }

    public override void OnUpdate(){}

    public override void OnLateUpdate(){}

    /// <summary>
    /// Uses physics to calculate initial velocities of arrow
    /// Time till hitting target is scaled based on distance from player (farther = longer time)
    /// </summary>
    void ShootArrow()
    {
        if (target == null) return;

        float dx = target.position.x - transform.position.x;
        float dy = target.position.y - transform.position.y;

        timeToHit = new Vector2(dx, dy).magnitude/ (7 * difficulty);

        float velocityX = dx / timeToHit;
        float velocityY = (dy + GRAVITY/2 * Mathf.Pow(timeToHit, 2)) / timeToHit;

        var arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);

    }
}
