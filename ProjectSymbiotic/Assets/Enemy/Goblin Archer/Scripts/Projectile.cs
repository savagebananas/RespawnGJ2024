using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private int direction = 1;

    public string targetTag; // tag of objects the projectile will hit
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.velocity.x < 0)
        {
            rend.flipX = true;
        }
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x)*Mathf.Rad2Deg);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coll");
        if (collision.gameObject.tag == "Player1" && targetTag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(1);
        }
        if (collision.gameObject.tag == "Player2" && targetTag == "Player")
        {
            collision.gameObject.GetComponent<Player2Movement>().TakeDamage(1);
        }
        if (collision.gameObject.tag == "Enemy" && targetTag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }

}
