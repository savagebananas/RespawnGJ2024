using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateFriction : MonoBehaviour
{
    private Rigidbody2D rb;
    private SeesawHingeScript seesaw;
    private FixedJoint2D joint;
    List<Rigidbody2D> stickableCollisions = new();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        seesaw = FindAnyObjectByType<SeesawHingeScript>();
        joint = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joint.enabled) return;

        foreach (Rigidbody2D rb1 in stickableCollisions)
        {
            if (rb1 != null)
            {
                if (Mathf.Abs((rb.rotation - rb1.rotation) % 90) < 1 && (rb1.GetComponent<SeesawHingeScript>() || (Vector2.Angle(seesaw.GetNormalVector(), GetDistanceVector(rb1)) < 30)))
                {
                    joint.connectedBody = rb1;
                    joint.enabled = true;
                    rb.tag = "CrateStick";
                }
            }
        }
    }

    private Vector2 GetDistanceVector(Rigidbody2D rbOther)
    {
        return new Vector2(rb.position.x - rbOther.position.x, rb.position.y - rbOther.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CrateStick"))
        {
            stickableCollisions.Add(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CrateStick"))
        {
            stickableCollisions.Remove(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
