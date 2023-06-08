using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE2Activator : OpenClose
{
    public GameObject QTE2;
    //public GameObject Photo;
    private bool isQTEActive = false;
    private bool haspressedbefore = false;
    private void Start()
    {
        QTE2.SetActive(false);
      //  Photo.SetActive(false);
      ButtonOpen.SetActive(false);
    }
    void OnEnable() {
        QTE2Script.OnBoolValueChanged += HandleBoolValueChanged;
    }
    void OnDisable() {
        QTE2Script.OnBoolValueChanged -= HandleBoolValueChanged;
    }
    void HandleBoolValueChanged(bool value){
       // ButtonClose.SetActive(true);
       // Photo.SetActive(true);
        textBox.SetActive(true);
    }
    public void Update(){

    }
    public void OpenButtonPressed(){
         if (!haspressedbefore && !isQTEActive){
            ExeuterTrigger("TrOpen");
            isQTEActive = true;
            QTE2.SetActive(true);
            ButtonOpen.SetActive(false);
          //  ButtonClose.SetActive(false);
         }
         else{
            OnOpenButtonClick();
            //Photo.SetActive(true);
          }
         isQTEActive = false;
         haspressedbefore = true;
    }


}