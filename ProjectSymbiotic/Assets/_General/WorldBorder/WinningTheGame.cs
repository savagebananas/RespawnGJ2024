using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class WinningTheGame : MonoBehaviour
{
    public GameObject p1, p2;
    public string stageName;
    public float TimeToNextStage=6f;
    private float Timecd;
    public Collider2D father;
    public static bool Won;

    public void DestroyAllUnneed()
    {
        NeedToDestroyWhenWinning[] objectsToDestroy = FindObjectsOfType<NeedToDestroyWhenWinning>();
        foreach (NeedToDestroyWhenWinning obj in objectsToDestroy)
        {
            Destroy(obj.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject==p1)
        {
            if (!other.gameObject.GetComponent<PlayerMovement>().won)
            {
                p2.transform.position = new Vector2(p2.transform.position.x, p1.transform.position.y);
                p1.GetComponent<PlayerMovement>().WinningTheGame();
                p2.GetComponent<Player2Movement>().WinningTheGame();
                Timecd = TimeToNextStage;
                father.isTrigger = false;
                DestroyAllUnneed();
                Won = true;
            }
        }
        else if (other.gameObject == p2)
        {
            if (!other.gameObject.GetComponent<Player2Movement>().won)
            {
                p1.transform.position = new Vector2(p1.transform.position.x, p2.transform.position.y);
                p1.GetComponent<PlayerMovement>().WinningTheGame();
                p2.GetComponent<Player2Movement>().WinningTheGame();
                Timecd = TimeToNextStage;
                father.isTrigger = false;
                DestroyAllUnneed();
                Won = true;
            }
        }
        else { Debug.Log("Not verified."); }
    }
    void Start()
    {
        Won = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Timecd > 0)
        {
            Timecd -= Time.deltaTime; 
            if (Timecd < 0) SceneManager.LoadScene(stageName);
            p1.GetComponent<PlayerMovement>().anim.SetBool("isWalking", true);
            p2.GetComponent<Player2Movement>().anim.SetBool("isWalking", true);
            //p1.GetComponent<PlayerMovement>().horizontal = 1;
            //p2.GetComponent<Player2Movement>().horizontal= 1;
        }
    }
}
