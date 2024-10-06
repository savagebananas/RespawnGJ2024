using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinShoot : MonoBehaviour
{
    public float sbs = 1.0f;
    private float ShootingCoolDown;
    private ShootEvent Event;
    // Start is called before the first frame update
    void Start()
    {
        ShootingCoolDown = sbs;
        Event = GetComponent<ShootEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootingCoolDown -= Time.deltaTime;
        if (ShootingCoolDown <=0)
        {
            Event.Shoot();
            ShootingCoolDown = sbs;
        }
    }
}
