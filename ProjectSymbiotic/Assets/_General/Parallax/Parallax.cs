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

        transform.position = new Vector2(transform.position.x, transform.position.y - GameManager.GetScore() / distanceFromCamera);
    }

    public void SetHeight(float h)
    {
        height = h;
    }
}
