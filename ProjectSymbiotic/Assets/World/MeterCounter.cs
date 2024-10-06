using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeterCounter : MonoBehaviour
{
    static TMP_Text txmp;

    void Start()
    {
        txmp = GetComponent<TMP_Text>();
    }


    public static void UpdateUI(float n)
    {
        txmp.text = n.ToString("F2") + "m";
    }

}
