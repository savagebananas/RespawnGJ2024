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
    private float initPlace = 129f;
    private float initSelect = 154f;
    private float press = -529f;
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
        //Debug.Log(transform.position);
        rectTransform = GetComponent<RectTransform>();
        FinalPosition = initPlace;
        myButton.onClick.AddListener(OnButtonPressed);
    }

    // Called when the button is clicked
    void OnButtonPressed()
    {
        FinalPosition = press;
        velocity = 30;
        WorldButtonMonitor.PressEvent(buttonName);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!myButton.interactable) return;
        if (FinalPosition > press)
        {
            FinalPosition = initSelect;
            velocity = 30;
        }
    }

    // This method is called when the mouse stops hovering over the button
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!myButton.interactable) return;
        if (FinalPosition > press)
        {
            FinalPosition = initPlace;
            velocity = 0;
        }
    }

    public void NormalReset()
    {
        FinalPosition = initPlace;
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
                if (rectTransform.anchoredPosition.x == press)
                {
                    WorldButtonMonitor.WorldActivate(buttonName);
                }
            }
        }
    }
}
