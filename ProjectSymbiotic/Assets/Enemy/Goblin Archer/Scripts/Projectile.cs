using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer rend;
    private CircleCollider2D circleCollider;

    public bool pointTowardsTarget = true;
    private float angle = 0;

    public bool isFired = false;

    public string targetTag; // tag of objects the projectile will hit
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (!isFired) return;

        if (pointTowardsTarget) transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
        else
        {
            angle += 1000 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isFired) return;

        if (collision.gameObject.CompareTag("Player1") && targetTag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player2") && targetTag == "Player")
        {
            collision.gameObject.GetComponent<Player2Movement>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && targetTag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (targetTag == "Player") collision.gameObject.GetComponent<RockWall>()?.TakeDamage(1);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            circleCollider.enabled = false;
            rb.velocity = new Vector3(0, 3, 0);
            rb.gravityScale = 1;
        }
    }
}
