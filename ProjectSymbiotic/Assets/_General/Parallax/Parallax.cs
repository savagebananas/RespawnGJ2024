using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    public float distanceFromCamera;
    public float InitHeight = 0;

    void Update()
    {
        // Debug.Log("Score=" + GameManager.GetHeight());
        transform.position = new Vector2(transform.position.x, InitHeight-GameManager.GetHeight() / distanceFromCamera);
    }
}
