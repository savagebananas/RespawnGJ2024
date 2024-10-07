using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FallingObjectSpawner;

public class Obstacles : FallingSpawnState
{
    private FallingObjectSpawner spawner;
    public override void OnStart()
    {
        spawner = stateMachine.GetComponent<FallingObjectSpawner>();
        InitializeSpawnedObjects(objects, weights, spawnedObjects);
        spawner.AddSpawnedObjects(spawnedObjects);
    }
    public override void OnUpdate()
    {

    }
    public override void OnLateUpdate()
    {

    }
    public override void OnExit()
    {

    }
}
