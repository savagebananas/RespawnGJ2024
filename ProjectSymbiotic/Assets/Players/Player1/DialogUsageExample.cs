using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUsageExample : MonoBehaviour
{
    // Start is called before the first frame update
    private double time = 0;
    public int EventCount = 2;
    private int counter = 0;
    public float[] CallTime = new float[6];
    DialogManager P1, P2;
    
    void Start()
    {
        //Modify Test Times here
        P1 = GameObject.Find("Player").GetComponent<DialogManager>();
        P2 = GameObject.Find("Player 2").GetComponent<DialogManager>();
        CallTime[0] = 0.3f;
        CallTime[1] = 0.7f;
    }

    private void EventManager(int x)
    {
        switch (x)
        {
            case 0: P1.SetText("Litang Dingzhen",5.0f); break;
            case 1:  P2.SetText("ZhishiXuebao", 5.0f); break;
            default: break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (counter < EventCount)
        {
            if (time >= CallTime[counter])
            {
                EventManager(counter);
                counter++;
            }
        }
    }
}
