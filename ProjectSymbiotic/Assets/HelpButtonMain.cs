using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpButtonMain : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    public GameObject setting, settext,o1;
    //public GameObject b1, b2, b3;
    public void OnButtonClick()
    {
        setting.SetActive(true);
        settext.SetActive(true);
        o1.SetActive(true);
        setting.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
        Time.timeScale = 0;
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
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
