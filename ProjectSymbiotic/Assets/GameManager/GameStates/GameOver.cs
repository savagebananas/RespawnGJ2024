using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : CutScene
{
    [SerializeField] PlayerInput p1;
    [SerializeField] PlayerInput p2;

    [SerializeField] CinemachineImpulseSource screenShake;

    public override void StartCutscene()
    {
        CameraShake();
    }

    public override void EndCutscene()
    {
        // Restart button and main menu
    }

    public override void CameraShake()
    {
        screenShake.GenerateImpulse();
    }

    public override void UpdateCutscene()
    {
        throw new System.NotImplementedException();
    }
    public override bool StateEnd()
    {
        return false;
    }
}
