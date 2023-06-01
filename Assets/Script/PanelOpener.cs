using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelOpener : MonoBehaviour
{
    public GameObject Photo;
    public GameObject BOpen;
    public GameObject BClose;
    private bool _isOpen = false;
    private Textbox textbox;

    public AudioSource soundPlayer;

    private void Start()
    {
        Photo.SetActive(false);
        BOpen.SetActive(false);
        BClose.SetActive(false);
        textbox = GetComponent<Textbox>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isOpen)
        {
            BOpen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Photo.SetActive(false);
            BOpen.SetActive(false);
            BClose.SetActive(false);
        }
    }
    public void OnCloseButtonClick()
    {
        if (Photo != null)
        {
            bool isActive = Photo.activeSelf;
            Photo.SetActive(!isActive);
            
        }

            textbox.NextSentence();
            soundPlayer.Play();

    }
}
/*public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Info;
    public GameObject Button;

    private void Start()
    {
        Button.SetActive(false);
        Panel.SetActive(false);
        Info.SetActive(false);
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
             Info.SetActive(false);
        }
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            Info.SetActive(true);
        }

    }
}*/
