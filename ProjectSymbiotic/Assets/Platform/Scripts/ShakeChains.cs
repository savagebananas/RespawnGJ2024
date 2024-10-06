using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeChains : MonoBehaviour
{
    private int phase;
    public void Shake()
    {
        Vector2 posi = transform.position;
        if ((phase == 0)||(phase==3))
        {
            posi.x -= 0.01f;
            transform.position = posi;
        }
        else
        {
            posi.x += 0.01f;
            transform.position = posi;
        }
        phase++;
        if (phase == 4)
            phase = 0;
    }
    public void endShake()
    {
        while (phase != 0) { Shake(); }
    }
    void Start()
    {
        phase = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
