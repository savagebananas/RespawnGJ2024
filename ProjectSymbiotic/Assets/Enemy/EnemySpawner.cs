using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    private bool spawnedEnemy = false;

    private void Update()
    {
        if (transform.position.y <= 7 && transform.position.y >= -5 && !spawnedEnemy)
        {
            SpawnEnemy();
            spawnedEnemy = true;
        }
        // out of range
        else if (transform.position.y > 7 || transform.position.y < -5)
        {
            DespawnEnemies();
            spawnedEnemy = false;
        }
    }

    public void SpawnEnemy()
    {
        var e = Instantiate(enemy, transform.position, Quaternion.identity);
        e.transform.parent = transform;
    }

    private void DespawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);

        }
    }
}

    
