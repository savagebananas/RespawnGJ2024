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
            StartCoroutine(DestroyObject());
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public IEnumerator DestroyObject()
    {
        // Animation and particles

        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }
}
