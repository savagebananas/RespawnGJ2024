using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawMovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxRotationDegrees;
    public float resetSpeed;
    public float secondsPerUpdate;
    public float acceleration;
    float timer = 0;
    List<Collision2D> collisions = new();

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;

        float nextRotation = rb.rotation + rb.angularVelocity * Time.deltaTime;

        if (Math.Abs(nextRotation) >= maxRotationDegrees)
        {
            rb.angularVelocity = 0;
            rb.rotation = maxRotationDegrees * Mathf.Sign(rb.rotation);
        }

        if (collisions.Count == 0 && rb.rotation != 0)
        {
            if (timer >= secondsPerUpdate)
            {
                timer = 0;
                rb.angularVelocity = resetSpeed*Mathf.Sign(-rb.rotation);
            }

            Debug.Log($"Ang Vel: {rb.angularVelocity}, Next Rot: {nextRotation}");
            if (rb.angularVelocity < 0 ? nextRotation <= 0 : nextRotation >= 0)
            {
                rb.angularVelocity = 0; // Turns out writing to rb.angularVelocity results in unexpected behaviors lol whoopsies, gotta rewrite using transform or smth lol... shouldn't use the phsyics engine tho
                rb.rotation = 0;
            }
        } else // Right now, just accelerate counterclockwise
        {
            rb.angularVelocity += acceleration * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisions.Add(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisions.Remove(collision);
    }
}
