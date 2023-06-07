using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    public GameObject Box;
    public GameObject textBox;
    public GameObject ButtonOpen;

    public Health health;
    
    public Animator animator;
    private bool isOpen = false;
    

    public AudioSource soundPlayer;

    private void Start()
    {
        ButtonOpen.SetActive(false);
        
        textBox.SetActive(false);

        Health health = GetComponent<Health>();
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
        if (health.health == 100)
        {
            ExeuterTrigger("TrOpen");
            ButtonOpen.SetActive(false);
            isOpen = true;
 
        }
        else
        {
            textBox.SetActive(true);
            soundPlayer.Play();
        }
       
    }

}