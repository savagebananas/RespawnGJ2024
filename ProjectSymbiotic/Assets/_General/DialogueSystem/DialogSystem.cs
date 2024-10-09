using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private static double Totaltime=0;
    public static bool dialogPlaying = false;
    private static double PlayNextDialog = 0;
    private static int scriptDisplay = 0;
    private static GameObject p1, p2;
    private static DialogManager dm1,dm2;
    private static int TalkingState=0;
    private static void ShowScript(int x)
    {
        if (PlayerScripts.player[x]==1)
        {
            dm1.SetText(PlayerScripts.playerScripts[x], PlayerScripts.hold[x]);
            TalkingState = 1;
        }
        else
        {
            dm2.SetText(PlayerScripts.playerScripts[x], PlayerScripts.hold[x]);
            TalkingState = 2;
        }
    }
    /// <summary>
    /// Play the dialog from the starting index
    /// </summary>
    /// <param name="x"></param>
    public static void Playfrom(int x)
    {
        dialogPlaying = true;
        //Play scripts from the number until finding a -1 to end the conversation
        PlayNextDialog = PlayerScripts.connect[x];
        if (PlayNextDialog == -1) dialogPlaying = false;
        scriptDisplay = x;
        ShowScript(x);
    }
    void Start()
    {
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        dm1=p1.GetComponent<DialogManager>();
        dm2=p2.GetComponent<DialogManager>();
        Playfrom(0);
    }

    private bool CheckTalking()
    {
        if (TalkingState == 1) return dm1.talking;
        if (TalkingState==2) return dm2.talking;
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        Totaltime+= Time.deltaTime;
        if ((PlayNextDialog > 0) && (!CheckTalking()))
        { 
            PlayNextDialog -= Time.deltaTime; 
            if (PlayNextDialog <= 0 )
            {
                scriptDisplay++; 
                ShowScript(scriptDisplay);
            }
        }
    }
}
