using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTriggerer : MonoBehaviour
{
    // Start is called before the first frame update
    private int count;
    [SerializeField] Collider2D Floor;
    [SerializeField] PlayerMovement p1m;
    [SerializeField] Player2Movement p2m;
    [SerializeField] GameObject p1, p2;
    private bool eable;
    private float laste;
    public MainMenuManager main;

    private void OnTriggerStay2D(Collider2D collision)
    {
        laste = 0.05f;
    }
    void Start()
    {
        count = 0;
        eable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (laste > 0) laste -= Time.deltaTime;
        if ((laste>0) && (Input.GetKeyDown(KeyCode.E)) || (Input.GetKeyDown(KeyCode.O)))
        {
            count++;
            Debug.Log(count);
        }
        if ((count>=10)&&(!eable))
        {
            Floor.enabled = false;
            p1m.enabled = false;
            p2m.enabled = false;
            p1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
            p2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
            main.InitCutScene();
            eable = true;
        }
    }
}
