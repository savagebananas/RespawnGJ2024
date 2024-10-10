using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagManager : MonoBehaviour
{
    public GameObject[] stalags;
    private GameObject[] startStalags;
    public static int numStags;
    public static bool gobDone;
    public static bool gobHit;
    // Start is called before the first frame update
    void Start()
    {
        startStalags = stalags;
        gobDone = false;
        gobHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        numStags = stalags.Length;
        if(gobDone)
        {
            gobDone = false;
            gobHit = false;
            stalags = startStalags;
            foreach (var item in stalags)
            {
                Instantiate(item, item.transform, item.transform);
            }
        }
    }
}
