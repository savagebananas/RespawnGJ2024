using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionAverageOfPlayers : MonoBehaviour
{
    public Transform p1;
    public Transform p2;

    float x = 0;

    void Update()
    {
        x = (p1.position.x + p2.position.x) / 2;
        transform.position = new Vector2(x, transform.position.y);
    }
}
