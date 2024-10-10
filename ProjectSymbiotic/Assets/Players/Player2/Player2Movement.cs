using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player2Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public bool won = false;
    public float horizontal;
    public float vertical;
    public float speed = 8f;
    private float originalSpeed;
    private float jumpingPower = 15f;
    public bool isFacingRight = true;
    public bool canBeHurt = true;

    [HideInInspector]
    public int health;

    [SerializeField]
    private SeesawHingeScript seesaw;

    [SerializeField]
    private GameObject button;

    public StateMachineManager platform;
    public MovingUp mvUp;
    public Stationary stationary;
    public Animator anim;

    [SerializeField] private ParticleSystem dust;
    [SerializeField] private ParticleSystem jumpDust;

    public int startHealth;
    [SerializeField] HealthUI healthUI;

    public static bool isOneWhoPulls;

    void Start()
    {
        health = startHealth;
        originalSpeed = speed;
        anim = GetComponent<Animator>();
        won = false;
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
        if (seesaw != null)
        {
            float platformAngle = seesaw.GetAngle();
            if (isFacingRight && platformAngle > 0)
            {
                speed = originalSpeed - math.abs(platformAngle) / 10;
            }
            else if (!isFacingRight && platformAngle < 0)
            {
                speed = originalSpeed - math.abs(platformAngle) / 10;
            }
        }

        if (!IsOnButton())
        {
            //isOneWhoPulls = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if ((!won))
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
        if (collider.CompareTag("UpButton"))
        {
            collider.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("UpButton") && isOneWhoPulls)
        {
            isOneWhoPulls = false;
            platform.setNewState(stationary);
            collider.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void PullChain(InputAction.CallbackContext context)
    {
        if (GameManager.inEvent) return;
        if ((!won) && (SceneManager.GetActiveScene().name == "SampleScene"))
        {
            if (context.performed && IsOnButton())
            {
                isOneWhoPulls = true;
                PlayerMovement.isOneWhoPulls = false;
                platform.setNewState(mvUp);
            }

            if (context.canceled && isOneWhoPulls)
            {
                isOneWhoPulls = false;
                platform.setNewState(stationary);
            }
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .1f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, .1f, playerLayer);
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
        if (canBeHurt)
        {
            canBeHurt = false;
            StartCoroutine(IFrames());
            anim.SetTrigger("hurt");
            health -= damage;
            healthUI.LoseLife(health);
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

    IEnumerator IFrames()
    {
        yield return new WaitForSeconds(1.5f);
        canBeHurt = true;
    }

    private bool IsOnButton()
    {
        float distance = math.abs(this.transform.position.x - button.transform.position.x);
        return distance < 0.5;
    }
}