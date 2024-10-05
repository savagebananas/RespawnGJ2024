using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    //Button button;
    public string SceneName = "SampleScene";
    public void OnButtonClick()
    {
        Debug.Log("This is an event");
        SceneManager.LoadScene(SceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        //button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
