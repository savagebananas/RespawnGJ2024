using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawHingeScript : MonoBehaviour
{
    [SerializeField] private float resetSpeed;
    private HingeJoint2D hinge;
    private JointMotor2D motor;
    private Rigidbody2D rb;
    List<Collision2D> collisions = new();

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (collisions.Count == 0 && Math.Abs(rb.rotation) > 0.4)
        {
            motor = hinge.motor;
            motor.motorSpeed = resetSpeed*Mathf.Sign(rb.rotation);
            hinge.motor = motor;
            hinge.useMotor = true;
        }
        else if (collisions.Count == 0)
        {
            rb.rotation = 0;
            rb.freezeRotation = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisions.Add(collision);
        rb.freezeRotation = false;
        hinge.useMotor = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisions.Remove(collision);
    }
}
