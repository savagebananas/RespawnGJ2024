using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private Animator animator;
    [SerializeField] CinemachineVirtualCamera vcam;

    [SerializeField] Transform normalCamRef;
    [SerializeField] Transform bridgeCamRef;
    [SerializeField] Transform bossRoomCamRef;

    [SerializeField] Collider2D normalBounds;
    [SerializeField] Collider2D bossBounds;

    private void Awake()
    {
       animator = GetComponentInParent<Animator>();
    }

    public void SetCameraNormal()
    {
        ChangeCamRef(normalCamRef);
        animator.SetTrigger("normal");
        ChangeCamBounds(normalBounds);
    }

    public void SetCameraUp()
    {
        animator.SetTrigger("up");
        ChangeCamBounds(normalBounds);
    }

    public void SetCameraBossFight()
    {
        animator.SetTrigger("boss");
        // wait
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
