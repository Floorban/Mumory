using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject camold, camnew;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            camold.SetActive(false);
            camnew.SetActive(true);
        }
    }
}
