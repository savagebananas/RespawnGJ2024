using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressUp : MonoBehaviour
{
    public float velocity;
    private float cdown;
    public float def = 1.6f;
    ShakeChains shakeChains;
    ShakePlatform shakePlatform;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<DialogManager>() != null)
        {
            if ((Input.GetKey(KeyCode.E)))
            {

                if (cdown != 0)
                {
                    cdown -= Time.deltaTime;
                    if (cdown <= 0) cdown = 0;
                    shakeChains.Shake();
                    shakePlatform.Shake();
                }
                else
                {
                    GameManager.AddScore(Time.deltaTime * velocity);
                    shakeChains.Shake();
                    shakePlatform.Shake();
                }
                GameManager.AddScore(Time.deltaTime * velocity);
            }
            else
            {
                cdown = def;
                shakeChains.endShake();
                shakePlatform.EndShake();
            }
        }
        else
        {
            cdown = def;
            shakeChains.endShake();
            shakePlatform.EndShake();
        }
    }
    void Start()
    {
        cdown = def;
        shakeChains = GameObject.Find("Platform (RB)/Chain").GetComponent<ShakeChains>();
        shakePlatform = GameObject.Find("Platform (RB)/Seesaw").GetComponent<ShakePlatform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
