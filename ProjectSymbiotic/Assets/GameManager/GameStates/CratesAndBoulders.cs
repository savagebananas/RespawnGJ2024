using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratesAndBoulders : State
{
    static Difficulty.DifficultyModifier modifier = new Difficulty.DifficultyModifier(6, 1, 1, 1, new List<float> { 0.5f, 0.5f }, 6, 1);
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
