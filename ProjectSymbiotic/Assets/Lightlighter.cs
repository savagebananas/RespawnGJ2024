using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lightlighter : MonoBehaviour
{
    int phase = 0;
    float initInt = 0;

    void ApplyLight(int x)
    {
        if (x==0)
        {
            Light2D light2D = GetComponent<Light2D>();
            light2D.intensity= initInt;
        }
        else
        {
            Light2D light2D = GetComponent<Light2D>();
            light2D.intensity = 0.2f * initInt;
        }
    }

    void Start()
    {
        phase = 0;
        initInt=GetComponent<Light2D>().intensity;
    }

    // Update is called once per frame
    void Update()
    {
        int r = UnityEngine.Random.Range(0, 10);
        if (r<=8)
        {
            phase = 0;
            ApplyLight(phase);
        }
        else
        {
            phase = 1;
            ApplyLight(phase);
        }
    }
}
