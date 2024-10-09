using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeesawHingeScript : MonoBehaviour
{
    [SerializeField] private float resetSpeed;
    private HingeJoint2D hinge;
    private Rigidbody2D rb;
    private bool frozen = false;
    List<Collision2D> collisions = new();

    /// <summary>
    /// Gets the platform's rotation.
    /// </summary>
    /// <returns>The platform's angle in degrees, counter-clockwise is positive.</returns>
    public float GetAngle()
    {
        return rb.rotation;
    }

    public Vector2 GetNormalVector()
    {
        return new Vector2(Mathf.Sin(-rb.rotation*Mathf.Deg2Rad), Mathf.Cos(rb.rotation*Mathf.Deg2Rad));
    }

    /// <summary>
    /// Set the rotation limit of the platform, in degrees. It will be directionally symmetrical.
    /// </summary>
    /// <param name="angle">Maximum angle the platform can rotate</param>
    public void SetRotationLimit(float angle)
    {
        JointAngleLimits2D limits = hinge.limits;
        limits.max = Mathf.Abs(angle);
        limits.min = -Mathf.Abs(angle);
        hinge.limits = limits;
    }

    /// <summary>
    /// Freeze the platform at a certain rotation, in degrees.
    /// </summary>
    /// <param name="angle">Angle the platform freezes at</param>
    public void FreezeAtAngle(float angle)
    {
        rb.rotation = angle;
        Freeze();
    }

    /// <summary>
    /// Freeze the platform at the current angle.
    /// </summary>
    public void Freeze()
    {
        frozen = true;
        rb.freezeRotation = true;
    }

    /// <summary>
    /// Unfreeze the platform
    /// </summary>
    public void Unfreeze()
    {
        frozen = false;
        rb.freezeRotation = false;
    }

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (collisions.Count == 0 && Mathf.Abs(rb.rotation) > 0.4)
        {
            JointMotor2D motor = hinge.motor;
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
        
        if (!frozen)
        {
            rb.freezeRotation = false;
        }

        hinge.useMotor = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisions.Remove(collision);
    }
}
