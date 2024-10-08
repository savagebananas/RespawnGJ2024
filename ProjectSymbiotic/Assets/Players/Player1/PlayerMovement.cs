using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public bool won;
    public float horizontal;
    public float vertical;
    public float speed = 8f;
    private float originalSpeed;
    private float jumpingPower = 15f;
    private bool isFacingRight = true;
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

    public int startHealth;

    [SerializeField] private ParticleSystem dust;
    [SerializeField] private ParticleSystem jumpDust;

    private bool isOneWhoPulls;

    void Start()
    {
        health = startHealth;
        originalSpeed = speed;
        won = false;
        anim = GetComponent<Animator>();
        isOneWhoPulls = false;
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (horizontal < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
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
        //if (!won)
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
        if(collider.CompareTag("UpButton"))
        {
            isOnButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("UpButton") && isOneWhoPulls)
        {
            isOnButton = false;
            isOneWhoPulls = false;
            platform.setNewState(stationary);
        }
    }

    public void PullChain(InputAction.CallbackContext context)
    {
        if (!won)
        {
            if (context.performed && isOnButton)
            {
                isOneWhoPulls = true;
                platform.setNewState(mvUp);
            }

            if (context.canceled)
            {
                isOneWhoPulls = false;
                platform.setNewState(stationary);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .1f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, .1f, playerLayer);
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
            vertical = context.ReadValue<Vector2>().y;

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
        Debug.Log("I am winning");
        won = true;
        canBeHurt = false;
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
                DialogSystem.Playfrom(49);
            }
            if (health <= 0) 
            {
                Die();
            }
        }  
    }

    public void Die()
    {
        if (!PlayerScripts.shawn[2])
        {
            //PlayerScripts.shawn[2] = true;
            DialogSystem.Playfrom(31);
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