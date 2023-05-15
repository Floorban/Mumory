using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private TextMeshProUGUI _promptText;
   
    private Inventory inventory;

    

    private void Start()
    {
        // Find and cache the Inventory component on the player object
        inventory = FindObjectOfType<Inventory>();
        _promptText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        // Check if the interactor has Inventory component and if the player's collider and the key's collider intersect
        if (interactor.GetComponent<Inventory>() != null &&
            interactor.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
        {
            // Add the key to the inventory and disable the game object
            inventory.HasKey = true;
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
