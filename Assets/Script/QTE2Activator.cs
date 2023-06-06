using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE2Activator : OpenClose
{
    public GameObject QTE2;
    private bool isQTEActive = false;
    private bool haspressedbefore = false;
    private float minQTE2 = 0f;
    private float maxQTE2 = 100f;
    private int Victory = 0;
    private void Start()
    {
        QTE2.SetActive(false);
    }
    public void Update(){
        if(Victory >= 1){
            ButtonClose.SetActive(true);
            Debug.Log("helpme");
        }
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
    public void QTE2Victory()
{
    Victory++;
}
}