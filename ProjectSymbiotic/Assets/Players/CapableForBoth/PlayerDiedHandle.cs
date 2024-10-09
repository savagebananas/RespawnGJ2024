using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDiedHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject p1, p2;
    private static bool resetting = false;
    public static float resetvelo;
    private static float cod;
    public static void Reseter()
    {
        Time.timeScale = 0;
        resetting = true;
        resetvelo = (GameManager.GetHeight() / 5) +0.5f;
        //Debug.Log("Velo=" + resetvelo);
        cod = 1.5f;
        resetting = true;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (resetting)
        {
            //Debug.Log("reset");
            if (cod > 0)
            {
                cod -= Time.unscaledDeltaTime;
            }
            else if (GameManager.GetHeight() > 0)
            {
                if (GameManager.GetHeight()>= resetvelo * Time.unscaledDeltaTime)
                    GameManager.AddScore(-resetvelo * Time.unscaledDeltaTime);
                else
                    GameManager.AddScore(-GameManager.GetHeight());
            }
            else
            {
                p1.transform.position = new Vector2(-1, 0);
                p2.transform.position = new Vector2(1, 0);
                Time.timeScale = 1;
                p1.GetComponent<PlayerMovement>().health = 5;
                p2.GetComponent<Player2Movement>().health = 5;
                Debug.Log("Some people died.");
                resetting = false;
            }
        }
    }
}
