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
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void AddScore(float height)
    {
        score += height;
        MeterCounter.UpdateUI(score);

    }
    public static float GetScore()
    {
        return score;
    }
}
