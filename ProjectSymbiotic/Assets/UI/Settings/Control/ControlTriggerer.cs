using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlTriggerer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MainMenuManager main;
    private bool isMouseOver = false;
    public string objectName;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        isMouseOver = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseOver && Input.GetMouseButton(0))
        {
            switch (objectName)
            {
                case "Control": main.SettingsOpenControls(); break;
                case "Volume": main.SettingsOpenVolume(); break;
                case "Brightness": main.SettingsOpenBrightness(); break;
                default: Debug.Log("Input wrong name"); break;
            }

        }
    }
}
