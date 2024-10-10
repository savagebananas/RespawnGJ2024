using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : GameState
{
    public static bool bridgeDone;
    public override void OnExit()
    {
    }

    public override void OnLateUpdate()
    {

    }

    public override void OnStart()
    {
        Difficulty.SetDifficultyLevel(DifficultyLevel.Easy);
    }

    public override void OnUpdate()
    {
    }

    public override bool StateEnd()
    {
        if (bridgeDone)
            return GameManager.GetHeight() >= 600;
        else if (GameManager.GetHeight() >= 450)
        {
            bridgeDone = true;
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
