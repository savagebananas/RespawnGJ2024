using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float speed = 8f;
    private float originalSpeed;
    private float jumpingPower = 15f;
    public bool isFacingRight = true;
    public bool canBeHurt = true;

    [SerializeField]
    private SeesawHingeScript seesaw;

    public int health;

    void Start()
    {
        originalSpeed = speed;
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
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void TakeDamage(int damage)
    {
        if(canBeHurt)
        {
            health -= damage;
            if (health <= 0) 
            {
                Die();
            }
        }   
    }

    public void Die()
    {
        //destroy player spout blood play willhelm
        //PlayerDiedHandle.Reseter();
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
    }
}
