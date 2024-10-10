using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public PolygonCollider2D c1,c2;
    public CinemachineConfiner2D c2d;
    private int phase = 0;
    public void flip()
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
