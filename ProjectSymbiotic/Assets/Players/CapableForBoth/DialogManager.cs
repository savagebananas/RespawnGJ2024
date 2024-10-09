using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
using System.Transactions;
using System;


public class DialogManager : MonoBehaviour
{
    public GameObject dialog,Player;
    private TMP_Text dialogtext;
    private RectTransform dialogRect;
    private double RectVanishCoolDown = 0;
    private double TextDisplayTime = 0;
    private TextMeshProUGUI dialogUGUI;
    private bool TextDisplaying = false;
    private int WordCount=0;
    private string CompleteText;
    public bool talking = false;
    public Canvas canvas;
    private double TimeTillNextWord = 0;
    [SerializeField] double VanishTime = 1.0;
    [SerializeField] double cps = 6; //cps=character per second, so 6 characters are coming in 1 second
    // Start is called before the first frame update
    private void FindObject()
    {
        dialogRect=dialog.GetComponent<RectTransform>();
        if (dialogRect == null)
        {
            Debug.Log("DialogRect not found");
            Application.Quit(1);
        }
        dialogUGUI = dialog.GetComponent<TextMeshProUGUI>();
        if (dialogUGUI == null)
        {
            Debug.Log("UGUI not found");
            Application.Quit(1);
        }
        dialogtext= dialog.GetComponent<TMP_Text>();
    }
    private void DialogRelocate()
    {
        Camera cam = Camera.main; // Get the main camera
        // Calculate the height and width of the camera's view
        float cameraHeight = 2 * cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, Player.transform.position);
        float width = canvas.GetComponent<RectTransform>().anchoredPosition.x;
        float height = canvas.GetComponent<RectTransform>().anchoredPosition.y;
        // Step 2: Convert the screen position to anchored position
        dialogRect.anchoredPosition = new Vector2(screenPoint.x * width*2 /cameraWidth, screenPoint.y * height*2 /cameraHeight);
    }
    private void InitDialog()
    {
        dialogtext.text = "";
    }
    /// <summary>
    /// Clear the Text.
    /// You cannot Clear the Text Immediately.
    /// But it is going to vanish....
    /// </summary>
    public void ClearText() 
    {
        TextDisplayTime = 0;
        RectVanishCoolDown = VanishTime;
    }

    /// <summary>
    /// Set new dialog lines and duration
    /// </summary>
    /// <param name="newtext"><The dialogue>
    /// <param name="displaytime"><The time you want it to stay>
    public void SetText(string newtext,float displaytime) 
    {
        if (dialogtext.text!="")
        {
            dialogtext.text = "";
            RectVanishCoolDown = 0;
            TextDisplayTime = 0;
        }
        TextDisplayTime = displaytime;
        CompleteText = newtext;
        TextDisplaying = true;
        WordCount = 0;
        talking = true;
    }
    private void DialogStateCheck()
    {
        if ((TextDisplaying) && (CompleteText!=null) && (dialogtext.text.Length<CompleteText.Length))
        {
            if (TimeTillNextWord>0)
                TimeTillNextWord -= Time.deltaTime;
            if (TimeTillNextWord <=0)
            {
                WordCount++;
                TimeTillNextWord = 1 / cps;
                dialogtext.text = CompleteText.Substring(0, WordCount);
            }
        }
        else if (TextDisplaying)
        {
            if (TextDisplayTime>0)
            {
                TextDisplayTime -= Time.deltaTime;
                if (TextDisplayTime < 0)
                {
                    TextDisplayTime = 0;
                    RectVanishCoolDown = VanishTime;
                    talking = false;
                }
            }
            else 
            if (RectVanishCoolDown != 0)
            {
                RectVanishCoolDown -= Time.deltaTime;
                if (RectVanishCoolDown < 0)
                {
                    RectVanishCoolDown = 0;
                    TextDisplaying = false;
                    dialogtext.text = "";
                }
                else
                {
                    float alpha = (float)(RectVanishCoolDown / VanishTime);
                    dialogUGUI.color = new Color(255, 255, 255, alpha);
                }
            }
        }
    }
    void Awake()
    {
        FindObject();
        DialogRelocate();
        InitDialog();
    }

    // Update is called once per frame
    void Update()
    {
        DialogRelocate();
        DialogStateCheck();
    }
}
