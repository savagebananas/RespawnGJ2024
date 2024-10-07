using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockParticle : MonoBehaviour
{
    ParticleManager particle;
    public float cdown = 0;
    void Start()
    {
        particle = GetComponent<ParticleManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (cdown == 0)
        {
            particle.MakeParticle(0, -0.5f, 1);
            cdown = 0.5f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (cdown > 0)
        {
            cdown -= Time.deltaTime;
            if (cdown <= 0) cdown = 0;
        }
    }
}
