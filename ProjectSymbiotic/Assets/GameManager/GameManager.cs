using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class GameManager : StateMachineManager
{
    private static float score;
    public static GameObject black;
    public static bool inEvent;
    public static bool inCutscene;
    [SerializeField] GameState gameWinState;
    [SerializeField] GameState gameOverState;
    [SerializeField] GameState CurrentGameState;

    void Start()
    {
        MeterCounter.UpdateUI(score);
        if (CurrentGameState != null)
        {
            CurrentGameState.OnStart();
        }
    }


    // Update is called once per frame
    void Update()
    {
        //AddScore(Time.deltaTime); //Delete this line after testing!
        //MeterCounter.UpdateUI(score);
        if (CurrentGameState != null)
        {
            CurrentGameState.OnUpdate();
            if (CurrentGameState.StateEnd())
            {
                setNewState(CurrentGameState.nextState);
            }
        }
    }
    public static void AddScore(float height)
    {
        score += height;
        MeterCounter.UpdateUI(score);

        if (score >= 1000)
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
    private void LateUpdate()
    {
        if (CurrentGameState != null)
        {
            CurrentGameState.OnLateUpdate();
        }
    }
    public override void setNewState(State state)
    {
        if (CurrentGameState != null)
        {
            CurrentGameState.OnExit();
        }
        if (state != null)
        {
            CurrentGameState = (GameState)state;
            CurrentGameState.OnStart();
        }
    }
}



