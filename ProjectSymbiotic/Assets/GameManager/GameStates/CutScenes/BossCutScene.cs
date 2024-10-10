using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCutScene : CutScene
{
    [SerializeField] CameraSystem cameraSystem;

    public override void CameraShake()
    {
    }

    public override void EndCutscene()
    {
    }

    public override void StartCutscene()
    {
        duration = 4f;
        cameraSystem.CutsceneBossFight();
    }

    public override void UpdateCutscene()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        removeGoblins = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
