using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : GameState
{
    public override void OnExit()
    {
    }

    public override void OnLateUpdate()
    {
    }

    public override void OnStart()
    {
        Difficulty.SetDifficultyLevel(DifficultyLevel.Medium);
    }

    public override void OnUpdate()
    {
    }

    public override bool StateEnd()
    {
        return GameManager.GetHeight() >= 750;
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
