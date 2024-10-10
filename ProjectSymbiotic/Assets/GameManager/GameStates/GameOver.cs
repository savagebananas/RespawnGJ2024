using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : State
{
    [SerializeField] PlayerInput p1;
    [SerializeField] PlayerInput p2;

    [SerializeField] State restartMenu; // show UI

    public override void OnStart()
    {
        p1.enabled = false;
        p2.enabled = false;

        // 
    }

    public override void OnUpdate()
    {
        
    }
    public override void OnExit(){}

    public override void OnLateUpdate(){}

}
