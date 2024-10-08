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

    private float horizontal;
    public float speed = 8f;
    private float originalSpeed;
    private float jumpingPower = 15f;
    public bool isFacingRight = true;
    public bool canBeHurt = true;
    public int health;

    [SerializeField]
    private SeesawHingeScript seesaw;

    public StateMachineManager platform;
    public MovingUp mvUp;
    public Stationary stationary;
    public bool isOnButton = false;
    public Animator anim;

    void Start()
    {
        originalSpeed = speed;
        anim = GetComponent<Animator>();
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
        if(context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            // Jump Animation
            anim.SetTrigger("jump");
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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

    public void PullChain(InputAction.CallbackContext context){ 
        if(context.performed && isOnButton)
        {
            platform.setNewState(mvUp);
        }

        if(context.canceled)
        {
            platform.setNewState(stationary);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .1f);
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
        horizontal = context.ReadValue<Vector2>().x;

        if(context.started)
        {
            anim.SetBool("isWalking", true);
        }
        else if(context.canceled)
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void WinningTheGame()
    {
        //anim.SetTrigger("isWinning");
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
            if (health <= 0) 
            {
                Die();
            }
        }   
    }

    public void Die()
    {
        PlayerDiedHandle.Reseter();
        //destroy player spout blood play willhelm
    }

    IEnumerator Stunned()
    {
        yield return new WaitForSeconds(5);

        
        rb.constraints = RigidbodyConstraints2D.None;
    }
}