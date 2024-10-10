using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;

    [SerializeField] Transform normalCamRef;
    [SerializeField] Transform bridgeCamRef;
    [SerializeField] Transform bossRoomCamRef;

    [SerializeField] Collider2D normalBounds;
    [SerializeField] Collider2D bossBounds;

    public void SetCameraNormal()
    {
        ChangeCamRef(normalCamRef);
        ChangeCamBounds(normalBounds);
    }

    public void SetCameraBossFight()
    {
        ChangeCamRef(bossRoomCamRef);
        ChangeCamBounds(bossBounds);
    }

    private void ChangeCamRef(Transform transform)
    {
        vcam.Follow = transform;
    }

    private void ChangeCamBounds(Collider2D collider)
    {
        vcam.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = collider;
    }
}
