using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachineManager
{
    public Animator animnator;
    [SerializeField] State idle;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.OnUpdate();
        }
        if (GameManager.inCutscene && CurrentState != idle) setNewState(idle);
    }
}
