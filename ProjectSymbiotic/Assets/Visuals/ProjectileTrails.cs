using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is to allow Trail demonstration
/// Simply attach it to the gameObject and it shows the trails automatically
/// </summary>
public class ProjectileTrails : MonoBehaviour
{
    // Start is called before the first frame update
    public float InitAlpha = 0.6f;
    public float FullRemainTime = 0.4f;
    public float tps = 16; //Trails per second
    private float TimeTillNextTrail;
    private float TimeTillVanish;
    public bool isTrail = false;
    void Start()
    {
        TimeTillNextTrail = 1 / tps;
        TimeTillVanish = FullRemainTime;
        if (isTrail)
        {
            Renderer renderer = GetComponent<Renderer>();
            Color newColor = renderer.material.color;
            newColor.a = InitAlpha;
            renderer.material.color = newColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrail)
        {
            TimeTillVanish -= Time.deltaTime;
            if (TimeTillVanish <= 0)
                Destroy(gameObject);
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                Color newColor = renderer.material.color;
                newColor.a = InitAlpha * (TimeTillVanish / FullRemainTime);
                renderer.material.color = newColor;
            }
        }
        else
        {
            TimeTillNextTrail-= Time.deltaTime;
            if (TimeTillNextTrail <= 0)
            {
                GameObject clone = Instantiate(gameObject, transform.position, Quaternion.identity);
                Collider2D dc=clone.GetComponent<Collider2D>();
                if (dc != null) Destroy(dc);
                Rigidbody2D rb=clone.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                ProjectileTrails pt=clone.GetComponent<ProjectileTrails>();
                pt.isTrail = true;
                TimeTillNextTrail = 1 / tps;
            }
        }
    }
}
