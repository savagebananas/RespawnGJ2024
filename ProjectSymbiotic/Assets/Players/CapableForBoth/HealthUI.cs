using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] lives = new GameObject[3];
    void Start()
    {
        ResetLives();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoseLife(int livesLeft)
    {
        lives[livesLeft].SetActive(false);
        Debug.Log("Rip");
    }
    public void ResetLives()
    {
        foreach (GameObject life in lives)
        {
            life.SetActive(true);
        }
    }
}
