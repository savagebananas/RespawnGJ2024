using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LensMover : MonoBehaviour
{
    public static float LensSpeed = 1.0f;
    private static float tgt;
    public static void ChangeLens(float target)
    {
        tgt = target;
    }
    void Start()
    {
        tgt = 3.31f;
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
    }
}
