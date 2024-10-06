using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeterCounter : MonoBehaviour
{
    static TMP_Text txmp;
    public static float n;

    void Start()
    {
        txmp = GetComponent<TMP_Text>();
        n = 0;
        UpdateUI(n);
    }

    public static void UpdateUI(float n)
    {
        txmp.text = n.ToString("F2")+"m";
    }
    public static void AddHeight(float x)
    {
        n += x;
        UpdateUI(n);
    }
}
