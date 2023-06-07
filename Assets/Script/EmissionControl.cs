using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{
    public Material material;
    public Material material2;

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
           material2.EnableKeyword("_EMISSION");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            material.DisableKeyword("_EMISSION");
            material2.EnableKeyword("_EMISSION");

            //ClosePanel();
        }
    }

}
