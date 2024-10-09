using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : MonoBehaviour
{
    public int health;
    public float lifeTime = 15f;
    private float timer;

    void Start()
    {
        timer = lifeTime;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            Destroy(this.gameObject);
            Player2Attack.numWalls -= 1;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Player2Attack.numWalls -= 1;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
