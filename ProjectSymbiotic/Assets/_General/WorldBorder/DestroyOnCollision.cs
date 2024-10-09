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
            if (collision.gameObject.GetComponent<PlayerMovement>()!=null && !PlayerScripts.shawn[3])
            {
                //PlayerScripts.shawn[3] = true;
                DialogSystem.Playfrom(34);
            }
            if (collision.gameObject.GetComponent<Player2Movement>() != null && !PlayerScripts.shawn[2])
            {
                //PlayerScripts.shawn[2] = true;
                DialogSystem.Playfrom(34);
            }
            PlayerDiedHandle.Reseter();
        }
        else if (collision.gameObject.tag == "Level") return;
        else GameObject.Destroy(collision.gameObject);
    }
}
