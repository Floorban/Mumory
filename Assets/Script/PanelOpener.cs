using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelOpener : MonoBehaviour
{
    public GameObject Photo;
    public GameObject BOpen;
    public GameObject BClose;

    public GameObject Narration;
    private bool _isOpen = false;
    //private Textbox textbox;

    public AudioSource soundPlayer;

    private void Start()
    {
        Photo.SetActive(false);
        BOpen.SetActive(false);
        BClose.SetActive(false);
        Narration.SetActive(false);
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
            Narration.SetActive(false);
            
        }
    }
    public void OnOpenButtonClick()
    {
        BOpen.SetActive(false);
        BClose.SetActive(true);
        Photo.SetActive(true);
        Narration.SetActive(true);

    }

    public void OnCloseButtonClick()
    {
        BOpen.SetActive(true);
        BClose.SetActive(false);
        Photo.SetActive(false);
        Narration.SetActive(false);
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
