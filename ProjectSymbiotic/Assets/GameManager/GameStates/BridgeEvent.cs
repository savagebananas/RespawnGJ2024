using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeEvent : GameState
{
    // Start is called before the first frame update
    [SerializeField] GameState medium;
    public override void OnStart()
    {
        GameManager.inEvent = true;
    }

    // Update is called once per frame
    public override void OnUpdate()
    {

    }

    public override void OnLateUpdate()
    {

    }

    public override void OnExit()
    {
        GameManager.inEvent = false;
        nextState.nextState = medium;
    }

    public override bool StateEnd()
    {
        return false;
    }
}
