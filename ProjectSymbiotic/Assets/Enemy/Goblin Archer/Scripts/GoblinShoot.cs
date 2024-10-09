using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinShoot : State
{
    public Enemy enemyBase;

    private Transform target;
    public GameObject arrowPrefab;

    private float timeToHit;
    const float GRAVITY = 9.81f;
    private float arrowMass;
    public GameObject arrow;

    public State cooldownState; // Timer cooldown for shooting is in goblin idle state

    private void Awake()
    {
        arrowMass = arrowPrefab.GetComponent<Rigidbody2D>().mass;
    }

    public override void OnStart()
    {
        target = enemyBase.target;
        ShootArrow();
        stateMachine.setNewState(cooldownState);
    }

    /// <summary>
    /// Uses physics to calculate initial velocities of arrow
    /// Time till hitting target is scaled based on distance from player (farther = longer time)
    /// </summary>
    void ShootArrow()
    {
        if (target == null) return;

        float dx = target.position.x - transform.position.x;
        float dy = target.position.y - transform.position.y;

        timeToHit = new Vector2(dx, dy).magnitude / (7 * Enemy.difficulty);

        float velocityX = dx / timeToHit;
        float velocityY = (dy + GRAVITY / 2 * Mathf.Pow(timeToHit, 2)) / timeToHit;

        var arrowRb = arrow.GetComponent<Rigidbody2D>();
        arrowRb.bodyType = RigidbodyType2D.Dynamic;
        arrowRb.velocity = new Vector2(velocityX, velocityY);
        var projectileScript = arrow.GetComponent<Projectile>();
        projectileScript.targetTag = "Player";
        projectileScript.isFired = true;
        projectileScript.rend.flipX = true;

    }

    public override void OnUpdate() { }
    public override void OnLateUpdate() { }
    public override void OnExit() { }
}
