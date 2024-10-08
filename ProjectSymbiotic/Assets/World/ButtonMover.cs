using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonMover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button myButton;
    public float FinalPosition;
    private float velocity=0;
    public float IOgravity=500;
    private bool b1,b2;
    RectTransform rectTransform;
    public WorldButtonMonitor WorldButtonMonitor;
    public string buttonName;
    public void SetChildrenActive(GameObject gameobject, bool isActive)
    {
        // Iterate through each child of the parent object
        foreach (Transform child in gameobject.transform)
        {
            child.gameObject.SetActive(isActive); // Set the active state of each child
        }
    }

    void Start()
    {
        // Add listener for button press
        Debug.Log(transform.position);
        rectTransform = GetComponent<RectTransform>();
        FinalPosition = -200f;
        myButton.onClick.AddListener(OnButtonPressed);
    }

    // Called when the button is clicked
    void OnButtonPressed()
    {
        FinalPosition = -960;
        velocity = 30;
        Debug.Log("Button Pressed: " + myButton.name);
        WorldButtonMonitor.PressEvent(buttonName);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!myButton.interactable) return;
        if (FinalPosition > -960)
        {
            FinalPosition = -175;
            velocity = 30;
        }
        Debug.Log("Button Selected: " + gameObject.name);
    }

    // This method is called when the mouse stops hovering over the button
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!myButton.interactable) return;
        if (FinalPosition > -960)
        {
            FinalPosition = -200;
            velocity = 0;
        }
        Debug.Log("Button Deselected: " + gameObject.name);
    }

    public void NormalReset()
    {
        if ((name == "Help") || (name == "Settings"))
            SetChildrenActive(gameObject, false);
        FinalPosition = -200;
        velocity = 0;
        myButton.interactable = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (rectTransform.anchoredPosition.x<FinalPosition)
        {
            velocity += IOgravity * Time.deltaTime;
        }
        else if (rectTransform.anchoredPosition.x > FinalPosition)
        {
            velocity -= IOgravity * Time.deltaTime;
        }
        if (rectTransform.anchoredPosition.x != FinalPosition)
        {
            b1 = rectTransform.anchoredPosition.x > FinalPosition;
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + velocity*Time.deltaTime, rectTransform.anchoredPosition.y);
            b2= rectTransform.anchoredPosition.x > FinalPosition;
            if (b1 != b2)
            {
                rectTransform.anchoredPosition = new Vector2(FinalPosition, rectTransform.anchoredPosition.y);
                velocity = 0;
            }
        }
        if (rectTransform.anchoredPosition.x==-960)
        {
            WorldButtonMonitor.WorldActivate(buttonName);
        }
    }
}
