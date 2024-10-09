using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerScripts : MonoBehaviour
{
    public static string[] playerScripts = new string[1000];
    public static int[] player = new int[1000]; //1: from player1; 2: from player2;
    public static float[] connect=new float[1000]; //Time until next dialog. If this is the last one, set -1
    public static float[] hold=new float[1000];
    public static bool[] shawn = new bool[1000];
    void SetScript(int pos, string scr, int p, float b,float h=1.0f)
    {
        playerScripts[pos] = scr;
        player[pos] = p;
        connect[pos] = b;
        hold[pos] = h;
    }
    /// <summary>
    /// Input all the scripts downside.
    /// When you need to call them, see DialogSystem's "playfrom" function
    /// Sometimes you need to check if the dialog was shawn using boolean shawn[]
    /// </summary>
    void Awake()
    {
        // 0~4: Starting theme
        //Current call at: DialogSystem
        shawn[0] = false;
        SetScript(0, "Ouch! Where are we? Are we still in the States? (Press wasd to move and jump)", 1, 1);
        SetScript(1, "I don¡¯t know either! Oh¡­ What¡¯s under our feet? It¡¯s a seesaw! (Press ijkl to move and jump)", 2, 1);
        SetScript(2, "Keep balance please don¡¯t fall¡­ Wait, what does that button do?", 1, 1);
        SetScript(3, "Where", 2, 1);
        SetScript(4, "Just in the center of the seesaw. Let¡¯s try it! (Press E to interact)", 1, -1);

        //11~14: First press button
        //Current call at: MovingUp
        shawn[1] = false;
        SetScript(11, "Wow, it does go up! Let me have a try (Press U to interact)", 2, 2);
        SetScript(12, "Sure! Notice that it will not go up unless you press long enough!", 2, -1);

        //31~32: P1 dies; 34~35: P2 dies
        //Current call at: DestroyOnCollision//Player(2)Movement
        shawn[2] = false;
        SetScript(31, "You know it¡¯s very important to keep balance?", 1, 1f,1f);
        SetScript(32, "Alright. Trust me.", 2, -1);
        shawn[3] = false;
        SetScript(34, "¡­¡­", 1, 0.1f);
        SetScript(35, "No worries. Try again!", 2, -1);

        /*41~43 First Goblin Spawned 46~51 First Player's health below 60%
        *41~43 Current call at:
        *46~51 Current call at: Player(2)Movement
        */
        shawn[4] = false;
        SetScript(41, "Look at those green guys! It¡¯s insane!", 1, 1);
        SetScript(42, "Ah¡­ No! they are attacking us!", 1, 1);
        SetScript(43, "Watch out these arrows!", 2, -1);
        shawn[5] = false; //For both events
        SetScript(46, "Ouch! That hurts! Can¡¯t we attack the Goblin?", 1,1);
        SetScript(47, "Why not? Press q to attack them!", 2, 1);
        SetScript(48, "Alright! You can do that by pressing o too!", 1, -1);
        SetScript(49, "Ouch! That hurts! Can¡¯t we attack the Goblin?", 2, 1);
        SetScript(50, "Why not? Press o to attack them!", 1, 1);
        SetScript(51, "Alright! You can do that by pressing q too!", 2, -1);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("");
    }
}
