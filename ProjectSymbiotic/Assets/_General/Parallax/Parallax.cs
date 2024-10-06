using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{

    [Range(0.0f, 10.0f)] public float height; // height of platform
    public float distanceFromCamera;

    public List<GameObject> backgrounds = new List<GameObject>();

    void Update()
    {
        foreach (GameObject b in backgrounds)
        {
            b.transform.position = new Vector2(b.transform.position.x, b.transform.position.y - height / distanceFromCamera);

        } 
    }
}
