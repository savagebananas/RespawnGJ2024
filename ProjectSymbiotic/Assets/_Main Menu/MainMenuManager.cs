using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private bool buttonsActive = true;

    [SerializeField] private Animator buttonPivotAnimator;

    public PlayerInput player1Input;
    public PlayerInput player2Input;

    private void Awake()
    {
    }
}
