using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenClose : MonoBehaviour
{
    public GameObject Box;
    public GameObject textBox;
    public GameObject ButtonOpen;
    //public GameObject ButtonClose;
    public Animator animator;
    public PauseMenu pausemenu;

    public GameObject Photo;

     public GameObject Menu;
    private bool isOpen = false;
    

    public AudioSource soundPlayer;

    private void Start()
    {
        ButtonOpen.SetActive(false);
       // ButtonClose.SetActive(false);
        textBox.SetActive(false); 
        Photo.SetActive(false);
        Menu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            ButtonOpen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ButtonOpen.SetActive(false);
           // ButtonClose.SetActive(false);
            textBox.SetActive(false);
        }
    }

    public void ExeuterTrigger(string trigger)
    {
        if (Box != null)
        {
            var animator = Box.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }
    }

    public void OnOpenButtonClick()
    {
        ExeuterTrigger("TrOpen");
        ButtonOpen.SetActive(false);
        //ButtonClose.SetActive(true);
        Photo.SetActive(true);
        isOpen = true;
        textBox.SetActive(true);
        soundPlayer.Play();
        Menu.SetActive(true);
        
    }

    public void OnCloseButtonClick()
    {
        ExeuterTrigger("TrClose");
        ButtonOpen.SetActive(true);
       // ButtonClose.SetActive(false);
        isOpen = false;
        Photo.SetActive(false);
        textBox.SetActive(false);
        pausemenu.PauseGame();
        
    }
}