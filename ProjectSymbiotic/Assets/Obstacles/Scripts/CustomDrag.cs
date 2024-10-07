using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDrag : MonoBehaviour
{
    [SerializeField] private float linearDragX = 0;
    [SerializeField] private float linearDragY = 0;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector2(-(rb.velocity.x * linearDragX), -(rb.velocity.y * linearDragY)));
    }
}
