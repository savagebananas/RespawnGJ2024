using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private bool buttonsActive = true;

    [SerializeField] private Animator animator;
    [SerializeField] private CinemachineVirtualCamera camera;

    [SerializeField] private Transform camReference1; // for main menu and credit animations
    [SerializeField] private Transform camReference2; // for tracking players

    public PlayerInput player1Input;
    public PlayerInput player2Input;

    public static bool KeyChange=false;
    public GameObject control, volume, brightness;
    public Animator Settingani;
    private void DeactivateAllChildren(GameObject x, bool deactive = false)
    {
        // Loop through all child GameObjects
        for (int i = 0; i < x.transform.childCount; i++)
        {
            // Get the child at index i
            GameObject child = x.transform.GetChild(i).gameObject;

            // Set the child GameObject inactive
            child.SetActive(deactive);
        }
    }
    public void OpenSettingsMenu()
    {
        // Setrynn
        SwitchToCredits();
        Settingani.SetBool("Opened", true);
        SettingsOpenControls();
        // Hide Settings button
        // Settings buttons and stuff
    }

    public void CloseSettingsMenu()
    {
        SwitchToMainMenu();
        Settingani.SetBool("Opened", false);
    }

    public void SettingsOpenVolume()
    {
        DeactivateAllChildren(volume,true);
        DeactivateAllChildren(brightness);
        DeactivateAllChildren(control);
    }

    public void SettingsOpenControls()
    {
        DeactivateAllChildren(volume);
        DeactivateAllChildren(brightness);
        DeactivateAllChildren(control, true);
    }
    public void SettingsOpenBrightness()
    {
        DeactivateAllChildren(volume);
        DeactivateAllChildren(brightness,true);
        DeactivateAllChildren(control);
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
