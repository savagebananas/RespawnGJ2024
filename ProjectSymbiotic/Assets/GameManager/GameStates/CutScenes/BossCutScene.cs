using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boss cutscene for x amt of seconds, sets next state to boss event
/// </summary>
public class BossCutScene : CutScene
{
    [SerializeField] CameraSystem cameraSystem;

    public override void StartCutscene()
    {
        cameraSystem.CutsceneBossFight();
    }

    public override void EndCutscene(){}

    public override void UpdateCutscene(){}

    public override void CameraShake(){}
}
