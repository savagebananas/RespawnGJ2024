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

    private float horizontal;
    public float speed = 8f;
    private float originalSpeed;
    private float jumpingPower = 15f;
    private bool isFacingRight = true;

    public bool canBeHurt = true;
    public int health;

    [SerializeField]
    private SeesawHingeScript seesaw;

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

    public void GetStunned()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        StartCoroutine(Stunned());
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    public void Die()
    {
        //PlayerDiedHandle.Reseter();
    }

    IEnumerator Stunned()
    {
        yield return new WaitForSeconds(5);

        
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
