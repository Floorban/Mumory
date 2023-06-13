using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEActive : OpenClose
{
    public GameObject QTE2;
    //public GameObject Photo;
    private bool isQTEActive = false;
    public bool haspressedbefore = false;
    public CameraFollow camerafollow;

    public QTE qte;
    


    private Vector3 initialOffset;
    
    private void Start()
    {
        QTE2.SetActive(false);
      //  Photo.SetActive(false);
      ButtonOpen.SetActive(false);
      CameraFollow offset = GetComponent<CameraFollow>();
      qte = GetComponent<QTE>();

      
    }
    void OnEnable() {
        QTE.OnBoolValueChanged += HandleBoolValueChanged;
    }
    void OnDisable() {
        QTE.OnBoolValueChanged -= HandleBoolValueChanged;
    }
    void HandleBoolValueChanged(bool value){
       // ButtonClose.SetActive(true);
       // Photo.SetActive(true);
        //textBox.SetActive(true);
    }
    public void Update(){
        

    }
    public void OpenButtonPressed(){
         if (!haspressedbefore && !isQTEActive){
            ExeuterTrigger("TrOpen");
            isQTEActive = true;
            QTE2.SetActive(true);
            ButtonOpen.SetActive(false);
            //qte.hashappened = true;
            //camerafollow.offset = new Vector3(0, 10, 0);
            
          //  ButtonClose.SetActive(false);
         }
        
        
         //isQTEActive = false;
         haspressedbefore = true;
         
    }


}