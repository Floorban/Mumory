using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showText : MonoBehaviour
{
    public GameObject Object;
  
      void Start()
    {
        Object.SetActive(false);
    }

      void OnTriggerEnter()
      {
        Object.SetActive(true);
      }

      void OnTriggerExit()
      {
        Object.SetActive(false);
      }
  
   
}