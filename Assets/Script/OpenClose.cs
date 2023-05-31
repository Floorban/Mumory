using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenClose : MonoBehaviour
{
    public GameObject Box;
    public GameObject ButtonOpen;
    public GameObject ButtonClose;
    public Animator animator;
    private bool isOpen = false;
    private Textbox textbox;

    public AudioSource soundPlayer;

    private void Start()
    {
        ButtonOpen.SetActive(false);
        ButtonClose.SetActive(false);
        textbox = GetComponent<Textbox>();
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
            ButtonClose.SetActive(false);
        }
    }

    private void ExeuterTrigger(string trigger)
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
        ButtonClose.SetActive(true);
        isOpen = true;
        textbox.NextSentence();
        soundPlayer.Play();
    }

    public void OnCloseButtonClick()
    {
        ExeuterTrigger("TrClose");
        ButtonOpen.SetActive(true);
        ButtonClose.SetActive(false);
        isOpen = false;
        textbox.NextSentence();
    }
}