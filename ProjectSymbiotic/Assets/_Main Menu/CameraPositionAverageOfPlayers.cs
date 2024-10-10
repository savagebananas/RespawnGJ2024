using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionAverageOfPlayers : MonoBehaviour
{
    public Transform p1;
    public Transform p2;

    public bool changeY = true;

    void Update()
    {
        if (changeY)
        {
            var x = (p1.transform.position.x + p2.transform.position.x) / 2;
            var y = (p1.transform.position.y + p2.transform.position.y) / 2;
            transform.position = new Vector2(x, y);
        }
        else
        {
            var x = (p1.transform.position.x + p2.transform.position.x) / 2;
            transform.position = new Vector2(x, transform.position.y);
        }

    }
}
