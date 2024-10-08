using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private int phase;
    [SerializeField] float displacement = 0.01f;
    public void ShakeX()
    {
        Vector2 posi = transform.position;
        if ((phase == 0) || (phase == 3))
        {
            posi.x -= displacement;
            transform.position = posi;
        }
        else
        {
            posi.x += displacement;
            transform.position = posi;
        }
        phase++;
        if (phase == 4)
            phase = 0;
    }
    public void endShake()
    {
        while (phase != 0) { ShakeX(); }
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
