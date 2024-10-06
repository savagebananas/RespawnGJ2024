using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float ratio=0.66f;
    public static int frame = 30;
    private int phase = 0;
    private float singleshakecool = (float) (0.05 / frame);
    private static float amplitude;
    private static float RemainTime;
    public static Vector2 OriginalPlace;
    private float angle = Mathf.PI/2;
    /// <summary>
    /// Shake the camera with the density and time.
    /// </summary>
    /// <param name="density"></param>
    /// <param name="time"></param>
    public static void Shake(float density, float time)
    {
        amplitude = density;
        RemainTime = time;
    }
    private void ShakeIt()
    {
        float dx = Mathf.Cos(angle)*amplitude * Mathf.Sin(phase * Mathf.PI / frame);
        float dy = ratio*Mathf.Sin(angle)*amplitude * Mathf.Sin(phase * Mathf.PI / frame);
        transform.position = OriginalPlace+new Vector2(dx,dy);
        phase++;
        if (phase==120)
        {
            phase = 0;
            angle = UnityEngine.Random.Range(Mathf.PI / 4, Mathf.PI * 3 / 4);
        }
    }
    void Start()
    {
        amplitude = UnityEngine.Random.Range(0.5f, 0.7f);
        OriginalPlace = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (RemainTime>0)
        {
            RemainTime -= Time.deltaTime;
            Debug.Log(RemainTime);
            singleshakecool -= Time.deltaTime;
            if (singleshakecool<=0)
            {
                singleshakecool = (float)(0.05 / frame);
                ShakeIt();
            }
        }
        else
        {
            transform.position = OriginalPlace;
        }
    }
}
