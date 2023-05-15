using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class HUD : MonoBehaviour
{

    public Inventory Inventory;

    public GameObject MessagePanel;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            // if find the empty slot
            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                // store a reference to the item
                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            // if find in the UI
            if(itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;

                break;
            }
        }
    }    

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);
    }

     public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
}
*/