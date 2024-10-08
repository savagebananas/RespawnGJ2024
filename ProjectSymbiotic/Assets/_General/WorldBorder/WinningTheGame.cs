using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningTheGame : MonoBehaviour
{
    public GameObject p1, p2;
    public string stageName;
    public float TimeToNextStage=6f;
    private float Timecd;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered.");
        if (other.gameObject==p1)
        {
            p2.transform.position = new Vector2(p2.transform.position.x, p1.transform.position.y);
            p1.GetComponent<PlayerMovement>().WinningTheGame();
            p2.GetComponent<Player2Movement>().WinningTheGame();
            Timecd = TimeToNextStage;
        }
        else if (other.gameObject == p2)
        {
            p1.transform.position = new Vector2(p1.transform.position.x, p2.transform.position.y);
            p1.GetComponent<PlayerMovement>().WinningTheGame();
            p2.GetComponent<Player2Movement>().WinningTheGame();
            Timecd = TimeToNextStage;
        }
        else { Debug.Log("Not verified."); }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timecd > 0)
        {
            Timecd -= Time.deltaTime; 
            if (Timecd < 0) SceneManager.LoadScene(stageName);
        }
    }
}
