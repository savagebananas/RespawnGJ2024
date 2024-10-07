using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FallingObjectSpawner;

public abstract class FallingSpawnState : State
{
    public List<GameObject> objects;
    public List<float> weights;
    protected List<SpawnedObject> spawnedObjects;
}
