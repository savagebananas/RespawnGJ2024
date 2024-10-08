using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.GetComponent<PlayerMovement>()!=null)||
            (collision.gameObject.GetComponent<Player2Movement>() != null))
        {
            PlayerDiedHandle.Reseter();
        }
        else GameObject.Destroy(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
