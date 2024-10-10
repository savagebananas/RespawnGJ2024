using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public abstract class CutScene : GameState
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] SeesawHingeScript seesaw;

    [SerializeField] FallingObjectSpawner fallingObjSpawner;
    private EnemySpawner[] spawners;

    [SerializeField] protected float duration = 5f;

    /// <summary>
    /// If true will kill all goblins on the platform before cutscene starts
    /// </summary>
    [SerializeField] protected bool removeGoblins = false;
    private float timer;

    public abstract void CameraShake();
    public abstract void StartCutscene();
    public abstract void EndCutscene();
    public abstract void UpdateCutscene();

    public void PauseActivity()
    {
        

        Difficulty.SetDifficultyLevel(DifficultyLevel.Peaceful);

        // will change
        //seesaw.FreezeAtAngle(0);

        // Disable input
        player1.GetComponent<PlayerInput>().enabled = false;
        player2.GetComponent<PlayerInput>().enabled = false;

        // Players dont rotate platform
        player1.GetComponent<Rigidbody2D>().mass = 0;
        player2.GetComponent<Rigidbody2D>().mass = 0;

        // Destroy all falling objects
        List<FallingObject> fallingObjects = new List<FallingObject>(fallingObjSpawner.GetComponentsInChildren<FallingObject>());
        foreach (FallingObject obj in fallingObjects)
        {
            obj.DestroyObject();
        }

        // Disable spawners and destroy all goblins
        spawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.enabled = false;
            if (!removeGoblins) return;
            foreach (Transform child in spawner.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
    public void ResumeActivity()
    {
        player1.GetComponent<PlayerInput>().enabled = true;
        player2.GetComponent<PlayerInput>().enabled = true;
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.enabled = true;
        }
        player1.GetComponent<Rigidbody2D>().mass = GameConstants.PLAYER_MASS;
        player2.GetComponent<Rigidbody2D>().mass = GameConstants.PLAYER_MASS;
        //seesaw.Unfreeze(); //will change

    }
    public override void OnExit()
    {
        EndCutscene();
        ResumeActivity();
        GameManager.inCutscene = false;
    }

    public override void OnStart()
    {
        GameManager.inCutscene = true;
        timer = duration;
        CameraShake();
        PauseActivity();
        StartCutscene();
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        UpdateCutscene();
    }

    public override void OnLateUpdate()
    {
    }
    public override bool StateEnd()
    {
        return timer < 0;
    }
}
