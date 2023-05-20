using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Receiver : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private TextMeshProUGUI _promptText;
    public string InteractionPrompt => prompt;

    //public GameObject doorObject;
    public GameObject uiPanel;
    
    private void Start()
    {
        _promptText = GetComponentInChildren<TextMeshProUGUI>();

        uiPanel.SetActive(false);
    }

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasKey)
        {
            Debug.Log("Opening Door!");
            //doorObject.SetActive(false); // Deactivate the door object
            return true;
        }

        Debug.Log("No key found");
        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            uiPanel.SetActive(true); 

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(false); 

        }
    }

}
