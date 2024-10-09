using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUp : State
{
    /// <summary>
    /// The delay between the chain pull and the platform moving
    /// </summary>
    [SerializeField] float moveDelay = 0.6f;
    private float delayTimer;
    /// <summary>
    /// How fast the platform moves up
    /// </summary>
    public float velocity;
    [SerializeField] GameObject chain;
    [SerializeField] GameObject plat;
    private Shake shakeChains;
    private Shake shakePlatform;
    public Stationary normalState;
    public Animator chainAnimater;
    private bool chainMoving;

    void Start()
    {

    }

    public override void OnStart()
    {
        delayTimer = moveDelay;
        shakeChains = chain.GetComponent<Shake>();
        //shakePlatform = plat.GetComponent<Shake>();
    }

    public override void OnUpdate()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            shakeChains.ShakeX();
            //shakePlatform.ShakeX();

        }
        else
        {
            if (!chainMoving)
            {
                shakeChains.endShake();
                //shakePlatform.endShake();
                chainAnimater.SetBool("isMoving", true);
                chainMoving = true;
            }
            if (!WinningTheGame.Won)
            {
                GameManager.AddScore(velocity * Time.deltaTime);
                if (!PlayerScripts.shawn[1])
                {
                    PlayerScripts.shawn[1] = true;
                    DialogSystem.Playfrom(11);
                }
            }
        }

        // While shaking timer is active, shake the objects
        //shakePlatform.Shake();
    }

    public override void OnLateUpdate()
    {
        // Additional late-update logic can go here if needed.
    }

    public override void OnExit()
    {
        //shakeChains.endShake();
        chainAnimater.SetBool("isMoving", false);
        chainMoving = false;

        //shakePlatform.EndShake();
    }
}
