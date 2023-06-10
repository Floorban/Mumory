using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonText : MonoBehaviour
{
    public GameObject Textfield;
    
     private void Start()
    {
        Textfield.SetActive(false);
    }

    public void SetText(string text)
    {
        //Textfield.text = text;
         if (Textfield != null)
        {
            bool isActive = Textfield.activeSelf;
            Textfield.SetActive(!isActive);
        }
    }

    void OnTriggerExit()
    {
        if (Textfield != null)
        {
            Textfield.SetActive(false);
        }
    }
   
}
