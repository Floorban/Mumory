using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelOpener : MonoBehaviour
{
    public GameObject Photo;
    public GameObject BOpen;
    public GameObject BClose;

    public CameraFollow camerafollow;

     private Vector3 initialOffset;

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

        CameraFollow offset = GetComponent<CameraFollow>();
        initialOffset = camerafollow.offset;
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

            camerafollow.offset = initialOffset;
            
        }
    }
    public void OnOpenButtonClick()
    {
        BOpen.SetActive(false);
        BClose.SetActive(true);
        Photo.SetActive(true);
        Narration.SetActive(true);

        camerafollow.offset = new Vector3(0, 10, 0);

    }

    public void OnCloseButtonClick()
    {
        BOpen.SetActive(true);
        BClose.SetActive(false);
        Photo.SetActive(false);
        Narration.SetActive(false);
        soundPlayer.Play();
        
        camerafollow.offset = initialOffset;
        
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
