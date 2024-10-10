using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helps activate/cycle the behaviors of a game object
/// </summary>
public class StateMachineManager : MonoBehaviour
{
    public State CurrentState;

    void Start()
    {
        if (CurrentState != null)
        {
            CurrentState.OnStart();
        }
    }

    void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.OnUpdate();
        }
    }

    void LateUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.OnLateUpdate();
        }
    }

    public virtual void setNewState(State state)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        if (state != null)
        {
            CurrentState = state;
            CurrentState.OnStart();
        }
    }
}