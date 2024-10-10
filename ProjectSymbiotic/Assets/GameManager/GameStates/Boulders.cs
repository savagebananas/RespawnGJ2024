using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulders : GameState
{
    static Difficulty.DifficultyModifier modifier = new Difficulty.DifficultyModifier(6, 1, 1, 1, new List<float> { 0, 1 }, 6, 1);

    public override void OnExit()
    {
    }

    public override void OnLateUpdate()
    {

    }

    public override void OnStart()
    {
        Difficulty.SetCustomDifficulty(modifier);
    }

    public override void OnUpdate()
    {
    }

    public override bool StateEnd()
    {
        return GameManager.GetHeight() >= 100;
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
