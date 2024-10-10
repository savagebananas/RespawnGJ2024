using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulders : State
{
    [SerializeField] Difficulty.DifficultyModifier modifier;
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
