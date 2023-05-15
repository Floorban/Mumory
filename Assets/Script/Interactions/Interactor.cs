using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Interactor : MonoBehaviour
{
    [SerializeField] Transform interactionPoint;
    [SerializeField]  float interactionPointRadius = 0.5f;
    [SerializeField]  LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField]  int numFound;

    private IInteractable interactable;

    private void Update() {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (! interactionPromptUI.IsDisplayed) interactionPromptUI.SetUp(interactable.InteractionPrompt);

                if (Input.GetKeyDown(KeyCode.E)) interactable.Interact(this);
            }
        }
        else
        {
            if (interactable != null) interactable = null;
            if (interactionPromptUI.IsDisplayed) interactionPromptUI.Close();
        }
    }
}