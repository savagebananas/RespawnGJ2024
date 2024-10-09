using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GoblinSwordJump : State
{
    [SerializeField] private Enemy enemyBase;
    [SerializeField] private GoblinSwordChase swordChaseState; // state
    [SerializeField] private GoblinSwordStun stunState; // state
    public Rigidbody2D rb;
    public override void OnStart()
    {
        Debug.Log("Jump Start");
        //Jump into the air
        rb.AddForce(this.transform.up * 10, ForceMode2D.Impulse); 

        //Wait 1 second or so and move towards the player using swordChaseState
        StartCoroutine(WaitAndChase());
        
    }

    public override void OnUpdate()
    {
        if(enemyBase.isHitByRock)
        {
            stateMachine.setNewState(stunState);
        }
    }

    public override void OnLateUpdate(){}

    public override void OnExit(){}

    IEnumerator WaitAndChase()
    {
        yield return new WaitForSeconds(0.2f);
        stateMachine.setNewState(swordChaseState);
    }
}
