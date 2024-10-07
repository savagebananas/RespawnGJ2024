using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public StateMachineManager stateMachine;
    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract void OnLateUpdate();
    public abstract void OnExit();
}