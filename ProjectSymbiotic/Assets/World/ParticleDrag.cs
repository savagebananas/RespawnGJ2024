using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDrag : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance = 0.3f;  // Maximum distance to check
    public AudioManager audioManager;

    void Update()
    {
        if (Input.GetMouseButton(0))  
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            float distance = Vector2.Distance(transform.position, mouseWorldPosition);
            Debug.Log(distance);
            // Check if the distance is less than the maximum allowed distance
            if (distance < maxDistance)
            {
                Vector2 pos= transform.position;
                pos.x = mouseWorldPosition.x;
                if (pos.x < -12.17f) pos.x = -12.17f;
                if (pos.x > -7.17f) pos.x = -7.17f; 
                transform.position = pos;
            }
        }
        //audioManager.SetMusicVolume(100*(transform.position.x+12.17f)/5f);
    }
}
