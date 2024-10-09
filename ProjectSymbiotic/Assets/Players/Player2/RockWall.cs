using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : MonoBehaviour
{
    public int health;
    public float lifeTime = 10f;
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
        }

        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
