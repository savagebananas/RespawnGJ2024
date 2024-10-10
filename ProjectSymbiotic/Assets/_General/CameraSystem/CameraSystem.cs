using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private Animator animator;
    [SerializeField] CinemachineVirtualCamera vcam;
    [SerializeField] CinemachineConfiner2D cinemachineConfiner;

    [SerializeField] Transform normalCamRef; // middle platform
    [SerializeField] Transform averageCamRef; // avg of two players
    [SerializeField] Transform bossRoomCamRef; // boss room

    [SerializeField] PolygonCollider2D normalBounds;
    [SerializeField] PolygonCollider2D bossBounds;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void SetCameraNormal()
    {
        ChangeCamRef(normalCamRef);
        animator.SetTrigger("normal");
        ChangeCamBounds("normal");
    }

    public void CutsceneBridge()
    {
        ChangeCamBounds("normal");
        animator.SetTrigger("bridge");
    }

    public void CutsceneBossFight()
    {
        ChangeCamBounds("boss");
        animator.SetTrigger("boss");
    }
    private void ChangeCamRef(Transform transform)
    {
        vcam.Follow = transform;
    }
    public void ChangeCamRef(string cam)
    {
        switch (cam)
        {
            case "normal":
                vcam.Follow = normalCamRef;
                break;
            case "avg":
                vcam.Follow = averageCamRef;
                break;
            case "boss":
                vcam.Follow = bossRoomCamRef;
                break;
        }
    }

    private void ChangeCamBounds(string s)
    {
        if (s == "boss")
        {
            vcam.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = bossBounds;
        }
        else
        {
            vcam.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = normalBounds;
        }

    }
}
