using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackMask : MonoBehaviour
{
    public Image ima;
    public static float set;
    private static float cd;
    public static float shield;
    // Start is called before the first frame update
    void Start()
    {
        ima.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (shield > 0)
        {
            shield -= Time.deltaTime;
        }
        else if (set!=0 && cd==0)
        {
            cd = set;
        }
        else if (cd!=0)
        {
            cd-=Time.deltaTime;
            if (cd <= 0)
            { cd = 0; SceneManager.LoadScene("SampleScene"); }
            ima.color = new Color(0, 0, 0, 1-cd / set);
        }
    }
}
