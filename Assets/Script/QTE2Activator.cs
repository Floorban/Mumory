using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE2Activator : OpenClose
{
    public GameObject QTE2;
    private bool isQTEActive = false;
    private bool haspressedbefore = false;
    private void Start()
    {
        QTE2.SetActive(false);
    }
    void OnEnable() {
        QTE2Script.OnBoolValueChanged += HandleBoolValueChanged;
    }
    void OnDisable() {
        QTE2Script.OnBoolValueChanged -= HandleBoolValueChanged;
    }
    void HandleBoolValueChanged(bool value){
        ButtonOpen.SetActive(true);
    }
    public void Update(){
    }
    public void OpenButtonPressed(){
         if (!haspressedbefore && !isQTEActive){
            isQTEActive = true;
            QTE2.SetActive(true);
            ButtonOpen.SetActive(false);
            ButtonClose.SetActive(false);
         }
         else{
            OnOpenButtonClick();
          }
         isQTEActive = false;
         haspressedbefore = true;
    }

    public void CloseButtonPressed(){
        QTE2.SetActive(false);
        OnCloseButtonClick();
        isQTEActive = false;
    }
}