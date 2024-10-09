using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LensMover : MonoBehaviour
{
    public static float LensSpeed = 1.0f;
    public static float MoveSpeed = 2.0f;
    private static float tgt;
    private static Vector3 dest;
    /// <summary>
    /// Change the size of lens
    /// </summary>
    /// <param name="target"></param>
    public static void ChangeLens(float target)
    {
        tgt = target;
    }
    /// <summary>
    /// Change the position of lens
    /// </summary>
    /// <param name="target"></param>
    public static void MoveLens(Vector2 target)
    {
        dest = target;
    }
    void Start()
    {
        tgt = 3.31f;
        dest = transform.position;
    }
    private Vector3 Curved(Vector3 init)
    {
        float magi = init.magnitude / MoveSpeed;
        return init / magi;
    }

    void Update()
    {
        CinemachineVirtualCamera cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        float x = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        if (x < tgt)
        {
            x += LensSpeed * Time.deltaTime;
            if (x > tgt) x = tgt;
            cinemachineVirtualCamera.m_Lens.OrthographicSize = x;
        }
        else if (x > tgt)
        {
            x -= LensSpeed * Time.deltaTime;
            if (x < tgt) x = tgt;
            cinemachineVirtualCamera.m_Lens.OrthographicSize = x;
        }
        if (transform.position!=dest)
        {
            transform.position += Curved(dest - transform.position);
        }
    }
}
