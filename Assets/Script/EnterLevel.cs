using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EnterLevel : MonoBehaviour
{
    public GameObject Box;
    public GameObject ButtonOpen;

    public Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        ButtonOpen.SetActive(false);

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
            isOpen = true;
            
       
    }

}