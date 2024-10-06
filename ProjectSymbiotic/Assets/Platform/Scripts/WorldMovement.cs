using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class WorldMovement : MonoBehaviour
{
    public GameObject world;
    public float velocity = 2f;
    public float duration = 10f;
    private bool isMoving = false;
    private float timeLeft;
    void Start()
    {
        timeLeft = duration;
    }
    void Update()
    {
        if (isMoving && timeLeft > 0)
        {
            world.transform.Translate(Vector3.down * velocity);
            timeLeft -= Time.deltaTime;
        }
        if (isMoving && timeLeft <= 0)
        {
            isMoving = false;
            timeLeft = duration;
        }
    }
    public void MoveUp()
    {
        isMoving = true;
    }

}
