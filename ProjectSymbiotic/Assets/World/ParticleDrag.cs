using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleDrag : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance = 0.3f;  // Maximum distance to check
    public AudioManager audioManager;
    public GameObject l, r;
    private float left, right;
    public RectTransform canvasRectTransform; // Reference to your canvas RectTransform

    // Method to convert mouse position to canvas space
    public Vector2 GetMousePositionInCanvas(RectTransform canvasRectTransform)
    {
        Vector2 mousePosition = Input.mousePosition; // Get the mouse position in screen space
        Vector2 localPoint;

        // Convert screen position to local position in the canvas rect space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform,        // The canvas RectTransform to work with
            mousePosition,              // The screen space mouse position
            null,                       // Optional: Camera, set to null if using Screen Space Overlay canvas
            out localPoint              // Output: The local position inside the canvas
        );
        //Debug.Log(localPoint);
        return localPoint; // Return the local point in the canvas space
    }

    private void Start()
    {
        
    }
    void Update()
    {
        left = l.GetComponent<RectTransform>().anchoredPosition.x;
        right = r.GetComponent<RectTransform>().anchoredPosition.x;
        //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        if (Input.GetMouseButton(0))  
        {
            Vector2 localMousePosition = GetMousePositionInCanvas(canvasRectTransform);
            Vector2 localParticlePosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x-960, GetComponent<RectTransform>().anchoredPosition.y-42);
            float distance = Vector2.Distance(localParticlePosition, localMousePosition);
            //Debug.Log(distance);
            // Check if the distance is less than the maximum allowed distance
            if (distance < maxDistance)
            {
                Vector2 pos= GetComponent<RectTransform>().anchoredPosition;
                pos.x = localMousePosition.x+960;
                if (pos.x < left+960) pos.x = left+960;
                if (pos.x > right+960) pos.x = right+960; 
                GetComponent<RectTransform>().anchoredPosition = pos;
            }
        }
        //audioManager.SetMusicVolume(100*(transform.position.x-left)/(right-left));
    }
}
