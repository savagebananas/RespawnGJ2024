using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinBossShoot : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinBossCharge goblinChargeState; // state
    [SerializeField] private GoblinBossStun goblinStunState; // state
    [SerializeField] private GameObject player2;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject chainShot;

    public override void OnUpdate()
    {
        if(chainShot.GetComponent<ChainShot>().hasReturned)
        {
            Rigidbody2D p2rb = player2.GetComponent<Rigidbody2D>();
            p2rb.constraints = RigidbodyConstraints2D.None;
            stateMachine.setNewState(goblinChargeState);
        }
    }

    public override void OnStart()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        enemyBase.canBeHurt = false;
        Debug.Log("Boss is shooting");
        Shoot();
    }

    private void Shoot()
    {
        Instantiate(chainShot, this.transform.position, this.transform.rotation);
    }

    public override void OnLateUpdate(){}
    public override void OnExit()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Stalag")
        {
            stateMachine.setNewState(goblinStunState);
        }
    }
}
