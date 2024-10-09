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
        difficulty.SetDifficulty(DifficultyLevel.Easy);

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
            difficulty.SetDifficulty(DifficultyLevel.Hard);
        }
        else if (score > mediumThreshold)
        {
            difficulty.SetDifficulty(DifficultyLevel.Medium);
        }
    }
    public static float GetHeight()
    {
        return score;
    }
    public static void ChangeDifficulty(DifficultyLevel level)
    {
        difficulty.SetDifficulty(level);
    }

}
