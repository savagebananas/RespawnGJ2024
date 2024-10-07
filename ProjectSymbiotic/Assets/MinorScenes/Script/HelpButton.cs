using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    public GameObject setting, settext,o1;
    public GameObject b1, b2, b3;
    public void OnButtonClick()
    {
        setting.SetActive(true);
        settext.SetActive(true);
        o1.SetActive(true);
        setting.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.6f);
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
    }
    void Start()
    {
        button = GetComponent<Button>();
    }
    public void Setback()
    {
        setting.SetActive(false);
        settext.SetActive(false);
        o1.SetActive(false);
        b1.SetActive(true);
        b2.SetActive(true);
        b3.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
