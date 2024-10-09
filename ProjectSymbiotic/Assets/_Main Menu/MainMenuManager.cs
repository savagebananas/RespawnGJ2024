using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private bool buttonsActive = true;

    [SerializeField] private Animator animator;
    [SerializeField] private CinemachineVirtualCamera camera;

    [SerializeField] private Transform camReference1; // for main menu and credit animations
    [SerializeField] private Transform camReference2; // for tracking players

    public PlayerInput player1Input;
    public PlayerInput player2Input;


    public void OpenSettingsMenu()
    {
        // Setrynn
        SwitchToCredits();
        // Hide Settings button
        // Settings buttons and stuff
    }

    public void CloseSettingsMenu()
    {
        // Setrynn
    }

    public void SwitchToMainMenu()
    {
        animator.SetTrigger("MainMenu");
    }

    public void SwitchToCredits()
    {
        animator.SetTrigger("Credits");
        // ^ includes button to switch back to main menu
    }

    /// <summary>
    /// Triggered when play button is pressed
    /// Allow players to move around
    /// Change camera reference point to follow player
    /// </summary>
    public void SwitchToPlay()
    {
        animator.SetTrigger("Play");
        camera.Follow = camReference2;

        player1Input.enabled = true;
        player2Input.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
