using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.GetComponent<PlayerMovement>() != null) ||
            (collision.gameObject.GetComponent<Player2Movement>() != null))
        {
            PlayerDiedHandle.Reseter();
        }
        else if (collision.gameObject.tag == "Level") return;
        else GameObject.Destroy(collision.gameObject);
    }
}
