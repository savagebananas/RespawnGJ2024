using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressUp : MonoBehaviour
{
    public float velocity = 1;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<DialogManager>() != null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                MeterCounter.addmeter(Time.deltaTime * velocity);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
