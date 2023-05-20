using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private TextMeshProUGUI _promptText;
    public string InteractionPrompt => prompt;

    public GameObject doorObject;
    public GameObject uiGame;
    public ProgressBar progressBar;
    
    private void Start()
    {
        _promptText = GetComponentInChildren<TextMeshProUGUI>();
        doorObject.SetActive(true);
        uiGame.SetActive(false);
    }

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasKey)
        {
            Debug.Log("Opening Door!");
            doorObject.SetActive(false); // Deactivate the door object
            return true;
        }

        Debug.Log("No key found");
        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            uiGame.SetActive(true); // Show the mini-game UI
            //progressBar.isActive = true; // Set the progress bar to active

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiGame.SetActive(false); // Hide the mini-game UI
            progressBar.isActive = false; // Set the progress bar to inactive
        }
    }
}*/
