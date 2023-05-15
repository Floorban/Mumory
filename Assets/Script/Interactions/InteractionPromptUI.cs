using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera mainCam;
    //[SerializeField] private GameObject uiGame;
    [SerializeField] private TextMeshProUGUI _promptText;

    [SerializeField] private GameObject uiPanel;

    private void Start() 
    {
        mainCam = Camera.main;
        uiPanel.SetActive(false);
       // uiGame.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);

        
    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;

        uiPanel.SetActive(true);
       // uiGame.SetActive(true);
     
        IsDisplayed = true;

    }

    /*void OnTriggerEnter(Collider Interactive)
    {
        if (Interactive.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E))
        {
             uiGame.SetActive(true);
        }

        }
    }*/

    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
             uiGame.SetActive(true);
        }
    }*/


    public void Close()
    {
        uiPanel.SetActive(false);

       // uiGame.SetActive(false);

        IsDisplayed = false;
    }
}
