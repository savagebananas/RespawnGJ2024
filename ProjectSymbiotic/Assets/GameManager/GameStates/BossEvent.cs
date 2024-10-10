using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : GameState
{



    public override void OnExit()
    {
        GameManager.inEvent = false;
    }

    public override void OnLateUpdate()
    {

    }

    public override void OnStart()
    {
        GameManager.inEvent = true;
    }

    public override void OnUpdate()
    {
    }

    public override bool StateEnd()
    {
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
