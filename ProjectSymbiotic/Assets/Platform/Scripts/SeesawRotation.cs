using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawRotation : MonoBehaviour
{
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private float totalTorque;
    [SerializeField] private float rotationSpeed;

    List<Collision2D> collisions = new List<Collision2D>();


    void Start()
    {
        
    }

    void Update()
    {
        foreach (Collision2D c in collisions)
        {
            Transform obj = c.transform;

            // Get the distance from the object to the pivot
            Vector3 distanceToPivot = obj.position - pivotPoint.position;

            // Calculate the torque: mass * distance from pivot (for simplicity)
            float torque = obj.GetComponent<Rigidbody2D>().mass * distanceToPivot.magnitude;

            // You might also want to consider the direction the torque is being applied in 2D space (on the Z axis)
            float direction = Mathf.Sign(Vector3.Cross(Vector3.up, distanceToPivot).z);

            // Add this torque to the total torque
            totalTorque += torque * direction;
        }

        transform.Rotate(0f, 0f, totalTorque * rotationSpeed * Time.deltaTime);


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
