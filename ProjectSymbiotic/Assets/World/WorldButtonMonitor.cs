using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldButtonMonitor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Play, Credits,Quit;
    public Button play, credits,quit;
    float countdown = 0;
    //1. After 1s all button go left
    //2. When 
    public void SetChildrenActive(GameObject gameobject, bool isActive)
    {
        // Iterate through each child of the parent object
        foreach (Transform child in gameobject.transform)
        {
            child.gameObject.SetActive(isActive); // Set the active state of each child
        }
    }
    public void PressEvent(string name)
    {
        switch (name)
        {
            case "Play":
                quit.interactable = false; credits.interactable = false;
                quit.GetComponent<ButtonMover>().FinalPosition = -961.0f;
                credits.GetComponent<ButtonMover>().FinalPosition = -961.0f;
                break;
            case "Credits":
                play.interactable = false; quit.interactable= false;
                quit.GetComponent<ButtonMover>().FinalPosition = -961.0f;
                play.GetComponent<ButtonMover>().FinalPosition = -961.0f; break;
            case "Quit":
                play.interactable = false; credits.interactable = false;
                credits.GetComponent<ButtonMover>().FinalPosition = -961.0f;
                play.GetComponent<ButtonMover>().FinalPosition = -961.0f; break;
            default: break;
        }
    }
    public void WorldActivate(string name)
    {
        switch (name)
        {
            case "Play": countdown = 1.50f; break;
            case "Credits": SceneManager.LoadScene("Credits"); break;
            case "Quit": break;
            default: break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
                SceneManager.LoadScene("SampleScene");
        }
    }
}
