using System.Collections;
using System.Collections.Generic;
using Interactables;
using UnityEngine;
using UnityEngine.UI;

public class Chain : IInteractable
{
    public WorldMovement worldMovement;
    private bool interactable;
    private bool outline;
    public bool CanInteract()
    {
        return interactable;
    }

    public void InteractSelectedLoop()
    {
        return;
    }

    public void OnInteract()
    {
        worldMovement.MoveUp();
        interactable = false;
    }

    public void OnInteractionDeselected()
    {
        ToggleOutline();
    }

    public void OnInteractSelected()
    {
        //TODO : Add highlight
        throw new System.NotImplementedException();
    }
    public void SetInteractable(bool canInteract)
    {
        interactable = canInteract;
        ToggleOutline();

    }
    private void ToggleOutline()
    {
        //TODO: implement
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
