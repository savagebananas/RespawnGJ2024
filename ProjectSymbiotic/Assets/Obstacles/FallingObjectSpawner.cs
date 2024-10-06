using System.Collections;
using System.Collections.Generic;
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

    // List of prefabs
    [SerializeField] private List<GameObject> objects = new List<GameObject>();

    private void Start()
    {
        timer = timePerSpawn;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnObjects();
            timer = timePerSpawn;
        }
    }

    private void SpawnObjects()
    {
        int numOfObjects = Random.Range(minPerSpawn, maxPerSpawn + 1);
        for(int i = 0; i < numOfObjects; i++)
        {
            var obj = Instantiate(objects[Random.Range(0, objects.Count)], new Vector2(transform.position.x + Random.Range(-spawnerWidth / 2, spawnerWidth / 2), 
                transform.position.y + Random.Range(-spawnerHeight / 2, spawnerHeight / 2)), Quaternion.identity);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null) rb.AddForce(-obj.transform.position.normalized * force, ForceMode2D.Impulse);

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
