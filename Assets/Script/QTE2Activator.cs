using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE2Activator : OpenClose
{
    public GameObject QTE2;
    //public GameObject Photo;
    private bool isQTEActive = false;
    public bool haspressedbefore = false;
    public static System.Action OnButtonPress;
    private bool eventHappened = false;
    public CameraFollow camerafollow;
    public delegate void StageChangeEventHandler(int didHappen);
    public static event StageChangeEventHandler OnStageChange;
    public delegate void EventHappenedEventHandler(bool value);
    public static event EventHappenedEventHandler OnEventHappened;


    public QTE2Script qte2script;

    private Vector3 initialOffset;

    private void Start()
    {
        QTE2.SetActive(false);
        //  Photo.SetActive(false);
        ButtonOpen.SetActive(false);
        CameraFollow offset = GetComponent<CameraFollow>();
        qte2script = GetComponent<QTE2Script>();

    }
    void OnEnable()
    {
        QTE2Script.OnBoolValueChanged += HandleBoolValueChanged;
    }
    void OnDisable()
    {
        QTE2Script.OnBoolValueChanged -= HandleBoolValueChanged;
    }
    void HandleBoolValueChanged(bool value)
    {
        // ButtonClose.SetActive(true);
        // Photo.SetActive(true);
        textBox.SetActive(true);
    }
    public void Update()
    {
        if (haspressedbefore)
        {
            ButtonOpen.gameObject.SetActive(false);
            EventHandler();
        }
    }
    void EventHandler()
    {
        if (!eventHappened)
        {
            OnButtonPress?.Invoke();
            eventHappened = true;
        }
    }
    public void OpenButtonPressed()
    {
        if (!haspressedbefore && !isQTEActive)
        {
            ExeuterTrigger("TrOpen");
            isQTEActive = true;
            QTE2.SetActive(true);
            OnEventHappened?.Invoke(false);
            OnStageChange?.Invoke(1);
            ButtonOpen.SetActive(false);
            eventHappened = false;
            //camerafollow.offset = new Vector3(0, 10, 0);
            //  ButtonClose.SetActive(false);
        }

        isQTEActive = false;
        haspressedbefore = true;

    }


}