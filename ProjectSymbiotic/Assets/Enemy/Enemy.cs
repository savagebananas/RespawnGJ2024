using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int difficulty = 1;

    private Transform p1;
    private Transform p2;
    [HideInInspector] public Transform target;
    public bool aimLeft;

    [SerializeField] public float health = 1;

    [SerializeField] private StateMachineManager stateMachine;
    [SerializeField] State hurtState;
    [SerializeField] State deathState;

    public bool canBeHurt;

    public bool isHitPlayer = false;
    public bool isHitObject = false;
    public bool isHitByRock = false;

    private Animator animator;

    private void Start()
    {
        canBeHurt = true;
        p1 = GameObject.Find("Player1").transform;
        p2 = GameObject.Find("Player2").transform;
        SetClosestTarget();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetClosestTarget();
        Visuals();
    }

    public void TakeDamage(float dmg)
    {
        if(canBeHurt)
        {
            if (animator != null) animator.SetTrigger("hurt");
            Debug.Log("Take DMG");
            health -= dmg;
            if (health <= 0 && deathState != null) stateMachine.setNewState(deathState);
            else stateMachine.setNewState(hurtState);
        }
        
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

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("collision");
        //Crate or rock hit
        if (col.gameObject.layer == 7)
        {
            isHitObject = true;
        }

        //Player hit
        if (col.gameObject.layer == 3)
        {
            isHitPlayer = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 9)
        {
            isHitByRock = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        isHitObject = false;
        isHitPlayer = false;
    }

    void OnTriggerExit2D()
    {
        isHitByRock = false;
    }
}
