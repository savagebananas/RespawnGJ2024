using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : State
{
    public override void OnExit()
    {
    }

    public override void OnLateUpdate()
    {
    }

    public override void OnStart()
    {
        Difficulty.SetDifficultyLevel(DifficultyLevel.Hard);
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
