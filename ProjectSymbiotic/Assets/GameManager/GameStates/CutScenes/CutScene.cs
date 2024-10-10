using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public abstract class CutScene : State
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] SeesawHingeScript seesaw;
    
    [SerializeField] FallingObjectSpawner fallingObjSpawner;
    private EnemySpawner[] spawners;
    private List<Collision2D> onPlatform;

    [SerializeField] float duration = 10f;
    [SerializeField] State nextState;

    /// <summary>
    /// If true will kill all goblins on the platform before cutscene starts
    /// </summary>
    [SerializeField] bool removeGoblins = false;
    private float timer;

    public abstract void CameraShake();
    public abstract void StartCutscene();
    public abstract void EndCutscene();

    public void PauseActivity()
    {
        spawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);

        Difficulty.SetDifficultyLevel(DifficultyLevel.Peaceful);

        // will change
        seesaw.FreezeAtAngle(0);

        // Disable input
        player1.GetComponent<PlayerInput>().enabled = false;
        player2.GetComponent<PlayerInput>().enabled = false;

        // Players dont rotate platform
        player1.GetComponent<Rigidbody2D>().mass = 0; 
        player2.GetComponent<Rigidbody2D>().mass = 0;

        foreach (EnemySpawner spawner in spawners)
        {
            spawner.enabled = false;
        }

        List<FallingObject> fallingObjects = new List<FallingObject>(fallingObjSpawner.GetComponentsInChildren<FallingObject>());
        foreach (FallingObject obj in fallingObjects)
        {
            obj.DestroyObject();
        }

        if (removeGoblins)
        {
            // Everything falls through platform
            foreach (Collision2D collision in onPlatform)
            {
                if (collision.gameObject.tag.StartsWith("Player")) continue;
                collision.gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
        else
        {
            //TODO :
            //if destroyGoblin = false - deactivate all goblins
            //Difficulty Peaceful already stops goblin archer from shooting so all you have to do is deactivate the melee goblins

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
        seesaw.Unfreeze(); //will change
        //TODO : if destroyGoblin = false - reactivate all the goblins on the platform
        
    }
    public override void OnExit()
    {
        ResumeActivity();
    }

    public override void OnStart()
    {
        timer = duration;
        PauseActivity();
        StartCutscene();
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stateMachine.setNewState(nextState);
        }
    }

    public override void OnLateUpdate()
    {
    }
}
