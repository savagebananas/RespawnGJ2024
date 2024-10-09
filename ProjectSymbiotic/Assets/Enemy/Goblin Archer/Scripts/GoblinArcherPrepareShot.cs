using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherPrepareShot : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private SpriteRenderer rend;

    [SerializeField] private Transform bowPivot;
    [SerializeField] private Transform bow;

    [SerializeField] private GoblinShoot goblinShootState; // state

    [SerializeField] private GameObject arrowPrefab;

    private Transform target;
    [SerializeField] private float chargeTime; // time till arrow is shot
    private float timer;

    public override void OnStart()
    {
        target = enemyBase.target;
        timer = chargeTime;

        var projectile = Instantiate(arrowPrefab, bow.position, Quaternion.identity);
        if (enemyBase.aimLeft) projectile.GetComponent<SpriteRenderer>().flipX = false;
        else projectile.GetComponent<SpriteRenderer>().flipX = true;
        goblinShootState.arrow = projectile;
        Invoke(nameof(ShootState), chargeTime);
    }

    public override void OnUpdate(){}

    private void ShootState()
    {
        stateMachine.setNewState(goblinShootState);
    }

    public override void OnExit() { }

    public override void OnLateUpdate() { }

}
