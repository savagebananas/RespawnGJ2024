using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressUp : MonoBehaviour
{

    public float def = 0.6f;
    public GameObject chain, plat; // GameObjects to shake
    private ShakeChains shakeChains;
    private ShakePlatform shakePlatform;
    public GameManager gm;
    public MovingUp mvUp;
    /// <summary>
    /// The player who is currently pulling the chain(if any)
    /// </summary>
    public Collider2D pullPlayer;
    public State idle;




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gm.CurrentState == mvUp) return;
        // Check if the player is colliding with the object
        if (collision.tag.StartsWith("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                // Set GameManager state to MovingUp when "E" is pressed
                gm.setNewState(mvUp);
                pullPlayer = collision;

            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == pullPlayer)
        {
            Debug.Log("FUFU");
            gm.setNewState(idle);
            pullPlayer = null;
        }
    }

    private void Start()
    {
        shakeChains = chain.GetComponent<ShakeChains>();
        shakePlatform = plat.GetComponent<ShakePlatform>();
        idle = gm.GetComponent<Idle>();
    }
}
// public float velocity;
// private float cdown;
// public float def = 0.6f;
// public float stopshaking = 1.0f;
// private float shakecdown;
// public GameObject chain, plat;
// private ShakeChains shakeChains;
// private ShakePlatform shakePlatform;
// private float laste = 0.1f;
// // Start is called before the first frame update
// private bool Inpute()
// {
//     if (Input.GetKey(KeyCode.E))
//     {
//         laste = 0.05f;
//     }
//     if (laste < 0) return false;
//     return true;
// }
// private void OnTriggerStay2D(Collider2D collision)
// {
//     if ((collision.GetComponent<PlayerMovement>() != null)|| (collision.GetComponent<Player2Movement>() != null))
//     {
//         if (Inpute())
//         {
//             if (cdown != 0)
//             {
//                 cdown -= Time.deltaTime;
//                 shakecdown = stopshaking;
//                 if (cdown <= 0) cdown = 0;
//                 if (shakecdown > 0)
//                 {
//                     shakeChains.Shake();
//                     shakePlatform.Shake();
//                 }
//             }
//             else
//             {
//                 GameManager.AddScore(Time.deltaTime * velocity);
//                 shakecdown -= Time.deltaTime;
//                 if (shakecdown <= 0) shakecdown = 0;
//                 if (shakecdown > 0)
//                 {
//                     shakeChains.Shake();
//                     shakePlatform.Shake();
//                 }
//             }
//         }
//         else
//         {
//             cdown = def;
//             shakecdown = stopshaking;
//             shakeChains.endShake();
//             shakePlatform.EndShake();
//         }
//     }
//     else
//     {
//         if (cdown<def) cdown += Time.deltaTime;
//         shakecdown = stopshaking;
//         shakeChains.endShake();
//         shakePlatform.EndShake();
//     }
// }
// void Start()
// {
//     shakeChains=chain.GetComponent<ShakeChains>();
//     shakePlatform=plat.GetComponent<ShakePlatform>();
// }

// // Update is called once per frame
// void Update()
// {
//     if (laste > 0) laste -= Time.deltaTime;
// }
//}
