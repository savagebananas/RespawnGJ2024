using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    public float spawnerWidth = 10;
    public float spawnerHeight = 20;

    public float timePerSpawn = 5;
    public int minPerSpawn = 1;
    public int maxPerSpawn = 3;

    public float force = 1;

    private float timer = 0;

    public struct SpawnedObject
    {
        public GameObject obj;
        public float weight;

        public SpawnedObject(GameObject obj, float weight)
        {
            if (weight < 0) throw new System.Exception("SpawnedObjects can't have negative weights");
            this.obj = obj;
            this.weight = weight;
        }
    }

    // List of prefabs with weights
    [SerializeField] private List<GameObject> initialObjects = new();
    [SerializeField] public List<float> initialWeights = new();
    private static List<SpawnedObject> spawnedObjects = new();
    private List<float> rngMap = new(); // Contains values between 0 and 1, last value is 1.

    private void Start()
    {
        timer = timePerSpawn;

        InitializeSpawnedObjects(initialObjects, initialWeights, spawnedObjects);
        NormalizeWeights();
    }

    /// <summary>
    /// Make sure you know the order of the stored spawning objects.
    /// </summary>
    /// <param name="weights">The new spawning weight of each object</param>
    public void ChangeWeights(List<float> weights)
    {
        if (spawnedObjects.Count != weights.Count) throw new System.Exception("Invalid list size");
        
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            SpawnedObject obj = spawnedObjects[i];
            obj.weight = weights[i];
            spawnedObjects[i] = obj;
        }

        NormalizeWeights();
    }

    public static void InitializeSpawnedObjects(List<GameObject> objects, List<float> weights, List<SpawnedObject> spawnedObjects)
    {
        if (objects == null || weights == null || spawnedObjects == null) return;
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] == null) continue;
            if (i >= weights.Count)
            {
                spawnedObjects.Add(new SpawnedObject(objects[i], 1));
            }
            else
            {
                spawnedObjects.Add(new SpawnedObject(objects[i], weights[i]));
            }
        }
    }

    public void AddSpawnedObject(GameObject obj, float weight)
    {
        AddSpawnedObject(new SpawnedObject(obj, weight));
    }
    public void AddSpawnedObject(SpawnedObject obj)
    {
        spawnedObjects.Add(obj);
        NormalizeWeights();
    }
    public void AddSpawnedObjects(IList<SpawnedObject> objs)
    {
        foreach (SpawnedObject obj in objs)
        {
            spawnedObjects.Add(obj);
        }
        NormalizeWeights();
    }

    public void ClearSpawnedObjects()
    {
        spawnedObjects.Clear();
    }

    private void NormalizeWeights()
    {
        float totalWeight = 0;
        rngMap.Clear();

        foreach (SpawnedObject obj in spawnedObjects)
        {
            totalWeight += obj.weight;
        }
        if (totalWeight == 0) totalWeight++;
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            SpawnedObject obj = spawnedObjects[i];
            obj.weight /= totalWeight;
            spawnedObjects[i] = obj;
        }
        totalWeight = 0;
        foreach (SpawnedObject obj in spawnedObjects)
        {
            totalWeight += obj.weight;
            rngMap.Add(totalWeight);
        }
    }

    private GameObject ChooseObject()
    {
        float rng = Random.value;
        int i = 0;
        foreach (float val in rngMap)
        {
            if (rng < val)
            {
                return spawnedObjects[i].obj;
            }
            i++;
        }
        return null; // Shouldn't happen
    }

    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log("Checking");
        if (timer <= 0 && spawnedObjects.Count > 0)
        {
            Debug.Log("Spawning");
            SpawnObjects();
            timer = timePerSpawn;
        }
    }

    private void SpawnObjects()
    {
        int numOfObjects = Random.Range(minPerSpawn, maxPerSpawn + 1);
        for (int i = 0; i < numOfObjects; i++)
        {
            var obj = Instantiate(ChooseObject(), new Vector2(transform.position.x + Random.Range(-spawnerWidth / 2, spawnerWidth / 2),
                transform.position.y + Random.Range(-spawnerHeight / 2, spawnerHeight / 2)), Quaternion.identity);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null) rb.AddForce(-rb.mass * force * obj.transform.position.normalized, ForceMode2D.Impulse);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector2(transform.position.x - spawnerWidth / 2, transform.position.y + spawnerHeight / 2), new Vector2(transform.position.x + spawnerWidth / 2, transform.position.y + spawnerHeight / 2));
        Gizmos.DrawLine(new Vector2(transform.position.x + spawnerWidth / 2, transform.position.y + spawnerHeight / 2), new Vector2(transform.position.x + spawnerWidth / 2, transform.position.y - spawnerHeight / 2));
        Gizmos.DrawLine(new Vector2(transform.position.x + spawnerWidth / 2, transform.position.y - spawnerHeight / 2), new Vector2(transform.position.x - spawnerWidth / 2, transform.position.y - spawnerHeight / 2));
        Gizmos.DrawLine(new Vector2(transform.position.x - spawnerWidth / 2, transform.position.y - spawnerHeight / 2), new Vector2(transform.position.x - spawnerWidth / 2, transform.position.y + spawnerHeight / 2));


    }
}
