using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{
    public Material material;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            material.EnableKeyword("_EMISSION");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            material.DisableKeyword("_EMISSION");

            //ClosePanel();
        }
    }

}
