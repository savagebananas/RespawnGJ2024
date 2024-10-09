using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachineManager
{
    private static float score;
    [SerializeField] static Difficulty difficulty;
    static int mediumThreshold = 50;
    static int hardThreshold = 100;

    void Start()
    {
        difficulty = gameObject.GetComponent<Difficulty>();
        MeterCounter.UpdateUI(score);
        if (CurrentState != null)
        {
            CurrentState.OnStart();
        }
        difficulty.SetDifficulty(Level.Easy);

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
        if (score > hardThreshold)
        {
            difficulty.SetDifficulty(Level.Hard);
        }
        else if (score > mediumThreshold)
        {
            difficulty.SetDifficulty(Level.Medium);
        }
    }
    public static float GetHeight()
    {
        return score;
    }
    public static void ChangeDifficulty(Level level)
    {
        difficulty.SetDifficulty(level);
    }

}
