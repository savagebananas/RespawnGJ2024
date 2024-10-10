using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : GameState
{
    [SerializeField] CameraSystem cameraSystem;
    [SerializeField] Transform p1;
    [SerializeField] Transform p2;

    private bool inBossRoom = false;


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
        cameraSystem.ChangeCamRef("avg");

        // Disable spawners and destroy all goblins
        var spawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.enabled = false;
            foreach(Transform child in spawner.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        Difficulty.SetDifficultyLevel(DifficultyLevel.Peaceful);

        // Boss beat state is called in the state machine of boss (boss death)
    }

    public override void OnUpdate()
    {
        if (inBossRoom) return;
        if (p1.position.x < -9 && p2.position.x < -9)
        {
            cameraSystem.ChangeCamRef("boss");
            // CLOSE DOOR
            inBossRoom = true;
        }
    }

    public override bool StateEnd()
    {
        return false;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
