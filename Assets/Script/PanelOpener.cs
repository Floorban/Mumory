using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button;

    private void Start()
    {
        Button.SetActive(false);
        Panel.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Button.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Button.SetActive(false);
            Panel.SetActive(false);
        }
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
