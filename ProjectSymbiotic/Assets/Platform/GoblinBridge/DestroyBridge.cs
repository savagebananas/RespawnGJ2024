using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DestroyBridge : MonoBehaviour
{
    public GameObject bridge;
    public GameObject chain1;
    public GameObject chain2;
    public GameObject netRope;
    public static bool bridgeIsDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        bridgeIsDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(chain1 == null && chain2 == null && netRope == null)
        {
            //destroy bridge with animation
            bridgeIsDestroyed = true;
            
            StartCoroutine(BridgeBreak());

            //let the platform continue 
        } 
    }

    IEnumerator BridgeBreak()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(bridge);
    }
}
