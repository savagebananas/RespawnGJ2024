using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class GameManager : StateMachineManager
{
    private static float score;

    bool inEvent;

    [SerializeField] State gameWinState;
    [SerializeField] State gameOverState;


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

        if (score >= 1050)
        {
            // win state
        }

    }
    public static float GetHeight()
    {
        return score;
    }

    public void GameWin()
    {
        setNewState(gameWinState);

    }

    public void GameOver()
    {
        setNewState(gameOverState);
    }

}
