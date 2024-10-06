using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressUp : MonoBehaviour
{
    public float velocity = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<DialogManager>() != null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                MeterCounter.AddHeight(Time.deltaTime * velocity);
            }
        }
    }
}
