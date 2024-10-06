using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeterCounter : MonoBehaviour
{
    // Start is called before the first frame update
    static TMP_Text textt;
    public static void meterchange(int n)
    {
        textt.text = n.ToString()+"m";
    }
    void Start()
    {
        textt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
