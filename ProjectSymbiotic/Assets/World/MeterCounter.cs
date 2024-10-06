using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeterCounter : MonoBehaviour
{
    // Start is called before the first frame update
    static TMP_Text textt;
    static float n;
    public static void meterchange(float n)
    {
        textt.text = n.ToString("F2")+"m";
    }
    public static void addmeter(float x)
    {
        n += x;
        meterchange(n);
    }
    void Start()
    {
        textt = GetComponent<TMP_Text>();
        n = 0;
        meterchange(n);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
