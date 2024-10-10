using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class SingleKeyManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text keycode;
    private bool changing = false;
    private bool isMouseOver = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }
    public void ChangeKey()
    {
        if (!MainMenuManager.KeyChange)
        {
            MainMenuManager.KeyChange = true;
            changing = true;
            keycode.text = " ";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseOver && Input.GetMouseButton(0))
        {
            ChangeKey();
        }
        if (changing)
        {
            foreach (char c in Input.inputString)
            {
                if (char.IsLetterOrDigit(c) || char.IsPunctuation(c) || char.IsWhiteSpace(c))
                {
                    if (c == ' ') { keycode.text = "Sp"; keycode.fontSize = 24; }
                    else if ((c >= 'a') && (c <= 'z')) { keycode.text = char.ToUpper(c).ToString(); keycode.fontSize = 42; }
                    else { keycode.text = c.ToString(); keycode.fontSize = 42;}
                    changing = false;
                    MainMenuManager.KeyChange = false;
                }
            }
        }
    }
}
