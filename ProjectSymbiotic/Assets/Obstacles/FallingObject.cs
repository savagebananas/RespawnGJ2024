using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public int health;

    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
