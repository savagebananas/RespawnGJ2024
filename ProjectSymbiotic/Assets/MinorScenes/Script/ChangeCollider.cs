using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public static Collider2D c1,c2;
    public static CinemachineConfiner2D c2d;
    private static int phase = 0;
    public static void flip()
    {
        if (phase==0)
        {
            phase = 1;
            c2d.m_BoundingShape2D = c2;
        }
        else
        {
            c2d.m_BoundingShape2D = c1;
        }
    }
    void Start()
    {
        phase = 0;
        c1=GameObject.Find("MainMenuManager").gameObject.GetComponent<Collider2D>();
        c2 = GameObject.Find("FallingCameraConfiner").gameObject.GetComponent<Collider2D>();
        c2d=GetComponent<CinemachineConfiner2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
