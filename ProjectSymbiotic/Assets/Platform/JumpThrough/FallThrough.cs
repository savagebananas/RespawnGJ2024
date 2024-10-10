using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThrough : MonoBehaviour
{
    private Collider2D col;
    private bool playerOnPlatform;
    int playerOn = 0;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void Start()

    {
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(playerOnPlatform && playerOn == 1)
        {
            if(player1.GetComponent<PlayerMovement>().vertical < 0)
            {
                col.enabled = false;
                StartCoroutine(EnableCollider());
            }
        }

        if(playerOnPlatform && playerOn == 2)
        {
            if(player2.GetComponent<Player2Movement>().vertical < 0)
            {
                col.enabled = false;
                StartCoroutine(EnableCollider());
            }
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        col.enabled = true;
    }

    private void SetPlaterOnPlatform(Collision2D col, bool value)
    {
        if(col.gameObject.GetComponent<PlayerMovement>() != null)
        {
            var player = col.gameObject.GetComponent<PlayerMovement>();
            playerOnPlatform = value;
            playerOn = 1;
        }

        if(col.gameObject.GetComponent<Player2Movement>() != null)
        {
            var player = col.gameObject.GetComponent<Player2Movement>();
            playerOnPlatform = value;
            playerOn = 2;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        SetPlaterOnPlatform(col, true);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        SetPlaterOnPlatform(col, false);
        playerOn = 0;
    }
    
}
