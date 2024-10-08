using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private int phase;
    public void Shake()
    {
        Vector2 posi = transform.position;
        if (phase == 0)
        {
            posi.x -= 0.02f;
            transform.position = posi;
        }
        else
        {
            posi.x += 0.02f;
            transform.position = posi;
        }
        if (phase == 0)
            phase = 1;
        else phase = 0;
    }
    public void EndShake()
    {
        if (phase != 0) Shake();
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
