using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CameraShake.Shake(0.5f, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
