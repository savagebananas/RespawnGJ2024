using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float maxRotationDegrees;
    [SerializeField] private float resetSpeed;
    [SerializeField] private float secondsPerUpdate;
    [SerializeField] private float acceleration;
    
    private float angularVelocity = 0;
    private float timer = 0;
    List<Collision2D> collisions = new();

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Math.Abs(rb.rotation + rb.angularVelocity * Time.deltaTime) >= maxRotationDegrees)
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

            float nextRotation = rb.rotation + rb.angularVelocity * Time.deltaTime;

            //Debug.Log($"Ang Vel: {rb.angularVelocity}, Next Rot: {nextRotation}");
            if (rb.angularVelocity < 0 ? nextRotation <= 0 : nextRotation >= 0)
            {
                rb.freezeRotation = true; // Turns out writing to rb.angularVelocity results in unexpected behaviors lol whoopsies, gotta rewrite using transform or smth lol... shouldn't use the phsyics engine tho
                rb.rotation = 0;
            }
        } else // Right now, just accelerate counterclockwise
        {
            rb.freezeRotation = false;
            rb.angularVelocity += acceleration * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisions.Add(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Snap");
        collisions.Remove(collision);
    }
}
