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
    [SerializeField] new GameState CurrentState;

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
        if (CurrentState.StateEnd())
        {
            setNewState(CurrentState.nextState);
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
