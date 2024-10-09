using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    public bool won = false;
    public float horizontal;
    public float speed = 8f;
    private float originalSpeed;
    private float jumpingPower = 15f;
    public bool isFacingRight = true;
    public bool canBeHurt = true;
    
    [HideInInspector]
    public int health;

    [SerializeField]
    private SeesawHingeScript seesaw;

    public StateMachineManager platform;
    public MovingUp mvUp;
    public Stationary stationary;
    public bool isOnButton = false;
    public Animator anim;

    [SerializeField] private ParticleSystem dust;
    [SerializeField] private ParticleSystem jumpDust;

    public int startHealth;


    void Start()
    {
        health = startHealth;
        originalSpeed = speed;
        anim = GetComponent<Animator>();
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(!isFacingRight && horizontal > 0f)
        {
            Flip();
        }

        else if(isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        float platformAngle = seesaw.GetAngle(); 
        if(isFacingRight && platformAngle > 0)
        {
            speed =  originalSpeed - math.abs(platformAngle) / 10;
        }
        else if(!isFacingRight && platformAngle < 0)
        {
            speed = originalSpeed - math.abs(platformAngle) / 10;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
       // if (!won)
        {
            if (context.performed && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                // Jump Animation
                anim.SetTrigger("jump");
                dust.Stop();
                jumpDust.Play();
            }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "UpButton")
        {
            isOnButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "UpButton")
        {
            isOnButton = false;
            platform.setNewState(stationary);
        }
    }

    public void PullChain(InputAction.CallbackContext context)
    {
        if (!won)
        {
            if (context.performed && isOnButton)
            {
                platform.setNewState(mvUp);
            }

            if (context.canceled)
            {
                platform.setNewState(stationary);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .1f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        //if (!won)
        {
            horizontal = context.ReadValue<Vector2>().x;

            if (context.started)
            {
                anim.SetBool("isWalking", true);
                if (IsGrounded()) dust.Play();
                else dust.Stop();
            }
            else if (context.canceled)
            {
                anim.SetBool("isWalking", false);
                dust.Stop();
            }
        }
    }

    public void WinningTheGame()
    {
        Debug.Log("P2 is winning");
        canBeHurt = false;
        won = true;
    }

    public void GetStunned()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        StartCoroutine(Stunned());
    }

    public void TakeDamage(int damage)
    {
        if(canBeHurt)
        {
            anim.SetTrigger("hurt");
            health -= damage;
            if ((health <= startHealth * 0.6f) && (!PlayerScripts.shawn[5]))
            {
                PlayerScripts.shawn[5] = true;
                DialogSystem.Playfrom(46);
            }
            if (health <= 0) 
            {
                Die();
            }
        }   
    }

    public void Die()
    {
        if (!PlayerScripts.shawn[3])
        {
            //PlayerScripts.shawn[2] = true;
            DialogSystem.Playfrom(34);
        }
        PlayerDiedHandle.Reseter();
        //destroy player spout blood play willhelm
    }

    IEnumerator Stunned()
    {
        yield return new WaitForSeconds(5);

        
        rb.constraints = RigidbodyConstraints2D.None;
    }
}