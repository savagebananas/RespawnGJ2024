using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUp : State
{
    /// <summary>
    /// The delay between the chain pull and the platform moving
    /// </summary>
    public float moveDelay = 0.6f;
    private float delayTimer;
    /// <summary>
    /// How fast the platform moves up
    /// </summary>
    public float velocity;
    public GameObject chain;
    public GameObject plat;
    private ShakeChains shakeChains;
    private ShakePlatform shakePlatform;
    public Stationary normalState;
    public override void OnStart()
    {
        delayTimer = moveDelay;
        shakeChains = chain.GetComponent<ShakeChains>();
        //shakePlatform = plat.GetComponent<ShakePlatform>();
    }

    public override void OnUpdate()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
        }
        else
        {
            GameManager.AddScore(velocity * Time.deltaTime);
        }

        // While shaking timer is active, shake the objects
        shakeChains.Shake();
        //shakePlatform.Shake();
    }

    public override void OnLateUpdate()
    {
        // Additional late-update logic can go here if needed.
    }

    public override void OnExit()
    {
        shakeChains.endShake();
        //shakePlatform.EndShake();
    }
}
