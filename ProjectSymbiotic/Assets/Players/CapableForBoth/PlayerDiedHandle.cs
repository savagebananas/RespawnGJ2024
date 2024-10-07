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
        resetvelo = GameManager.GetHeight() / 10;
        cod = 1.5f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cod > 0) cod -= Time.unscaledDeltaTime;
        else if (GameManager.GetHeight()>0)
            GameManager.AddScore(-resetvelo * Time.unscaledDeltaTime);
        else
        {
            p1.transform.position = new Vector2(-1, 2);
            p2.transform.position = new Vector2(1, 2);
            Time.timeScale = 1;
            p1.GetComponent<PlayerMovement>().health = 5;
            //p2.GetComponent<Player2Movement>().health = 5;
        }
    }
}
