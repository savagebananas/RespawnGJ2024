using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public static string[] playerScripts = new string[1000];
    public static int[] player = new int[1000]; //1: from player1; 2: from player2;
    public static int[] connect=new int[1000]; //Time until next dialog. If this is the last one, set -1
    void SetScript(int pos, string scr, int p, int b)
    {
        playerScripts[pos] = scr;
        player[pos] = p;
        connect[pos] = b;
    }
    /// <summary>
    /// Input all the scripts downside.
    /// </summary>
    void Start()
    {
        SetScript(0, "XuebaoBizui", 1, 2);
        SetScript(1, "HuaiwoHaoshi", 2, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
