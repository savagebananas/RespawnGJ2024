using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeterCounter : MonoBehaviour
{
    [SerializeField] TMP_Text txmp;
    public static float x;


    public static void UpdateUI(float n)
    {
        x = n;
    }

    private void Update()
    {
        txmp.text = x.ToString("F2") + "m";
    }
}
