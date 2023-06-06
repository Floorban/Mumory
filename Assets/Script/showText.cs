using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showText : MonoBehaviour
{

    public Textbox textbox;
  
      void Start()
      {
        
      }

     private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            textbox.NextSentence();
        }
        
    }

   
}