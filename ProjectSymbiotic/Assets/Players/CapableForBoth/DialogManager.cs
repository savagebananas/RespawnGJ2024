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
    private GameObject dialog,Player;
    private TMP_Text dialogtext;
    private RectTransform dialogRect;
    private double RectVanishCoolDown = 0;
    private double TextDisplayTime = 0;
    private TextMeshProUGUI dialogUGUI;
    private bool TextDisplaying = false;
    private int WordCount=0;
    private string CompleteText;
    private double TimeTillNextWord = 0;
    [SerializeField] double VanishTime = 1.0;
    [SerializeField] double cps = 6; //cps=character per second, so 6 characters are coming in 1 second
    // Start is called before the first frame update
    private void FindObject()
    {
        dialog=transform.Find("Canvas/PlayerDialog").gameObject;
        if (dialog != null)
        {
            dialogtext = dialog.GetComponent<TMP_Text>();
        }
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
        Player = GameObject.Find("Player1");
        if (Player == null)
        {
            Player = GameObject.Find("Player2");
            if (Player != null) Debug.Log("Player2 Found");
        }// This is trying to fit in both p1 and p2 with same code
        if (Player == null)
        {
            Debug.Log("Player not found");
            Application.Quit(1);
        }
    }
    private void DialogRelocate()
    {
        dialogRect.anchoredPosition = new Vector2(0, 0);//Player.transform.position;
    }
    private void InitDialog()
    {
        dialogtext.text = "";
    }
    /// <summary>
    /// ClearText():
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
    /// CreateANewText:
    /// Start a new dialog to make a new text!
    /// </summary>
    /// <param name="newtext"><The container>
    /// <param name="displaytime"><The time you want it to stay>
    public void CreateANewText(string newtext,float displaytime) 
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
