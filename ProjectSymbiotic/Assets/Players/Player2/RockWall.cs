using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : MonoBehaviour
{
    public int health;

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(this);
        }
    }

    public void TakeDamage()
    {
        health -= 1;
    }
}
