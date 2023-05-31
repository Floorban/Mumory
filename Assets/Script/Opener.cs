using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour
{
    public GameObject OpenPanel = null;

    private bool _isInsideTrigger = false;

    public Animator _animator;

    public string OpenText = "Click on it to open";

    public string Closeext = "Click on it to close";

    private bool _isOpen = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
         if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            //_animator.SetBool("open", false);
            OpenPanel.SetActive(false);
        }
    }

    private bool isOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    void Update()
    {
        if (isOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {   
                _isOpen = !_isOpen;
                //OpenPanel.SetActive(false);
                _animator.SetBool("open", _isOpen);
            }
        }
    }
}

