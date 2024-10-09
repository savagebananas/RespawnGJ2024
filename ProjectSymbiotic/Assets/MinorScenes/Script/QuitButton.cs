using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    private float cd = 0;
    public void OnButtonClick()
    {
        Debug.Log("This is an event");
        cd = 0.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cd>0)
        {
            cd -= Time.deltaTime;
            if (cd<=0)
            {
                Application.Quit();
            }
        }
    }
}
