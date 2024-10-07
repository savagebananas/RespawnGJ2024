using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDrag : MonoBehaviour
{
    // Start is called before the first frame update
    //-60.3~198.4
    public float maxDistance = 0.3f;  // Maximum distance to check
    public AudioManager audioManager;

    void Update()
    {
        if (Input.GetMouseButton(0))  
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            // Calculate the distance from the GameObject to the mouse position
            float distance = Vector2.Distance(transform.position, mouseWorldPosition);
            // Check if the distance is less than the maximum allowed distance
            if (distance < maxDistance)
            {
                Vector2 pos= transform.position;
                pos.x = mouseWorldPosition.x;
                if (pos.x < -12.17f) pos.x = -12.17f;
                if (pos.x > -7.17f) pos.x = -7.17f; 
                transform.position = pos;
                Debug.Log(pos);
            }
        }
        //audioManager.SetMusicVolume(100*(transform.position.x+12.17f)/5f);
    }
}
