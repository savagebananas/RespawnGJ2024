using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private double Totaltime=0;
    public static void Playfrom(int x)
    {

    }
    void Start()
    {
        Playfrom(0);
    }

    // Update is called once per frame
    void Update()
    {
        Totaltime+= Time.deltaTime;
    }
}
