using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{

    private float height;
    public float distanceFromCamera;

    void Update()
    {
        Debug.Log("Score=" + GameManager.GetHeight());
        transform.position = new Vector2(transform.position.x, -GameManager.GetHeight()*25 / distanceFromCamera);
    }

    public void SetHeight(float h)
    {
        height = h;
    }
}
