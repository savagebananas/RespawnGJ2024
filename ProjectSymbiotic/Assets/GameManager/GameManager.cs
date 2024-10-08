using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachineManager
{
    private static float score;


    // Start is called before the first frame update
    void Start()
    {
        MeterCounter.UpdateUI(score);
        if (CurrentState != null)
        {
            CurrentState.OnStart();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //AddScore(Time.deltaTime); //Delete this line after testing!
        //MeterCounter.UpdateUI(score);
        if (CurrentState != null)
        {
            CurrentState.OnUpdate();
        }
    }
    public static void AddScore(float height)
    {
        score += height;
        MeterCounter.UpdateUI(score);
    }
    public static float GetHeight()
    {
        return score;
    }
}
