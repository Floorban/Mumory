using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE2Script : MonoBehaviour
{
    public Image Bar;
    public RectTransform ButtonContainer;
    private float _value = 0;
    public float DecreaseRate = 10f;
    public float IncreaseValueBy = 20f;
    public float BounceDuration = 0.2f;
    public float BounceScale = 1.2f;
    private int _stage = 1;
    public GameObject WinCondition;
    public GameObject LoseCondition;
    private Transform canvasP;
    private void Start()
    {
        canvasP = GameObject.Find("Canvas").GetComponent<Transform>();
        GameObject ButtonObject = GameObject.Find("ButtonClick");
        Transform ButtonClick = transform.Find("ButtonClick");
        Button button = ButtonClick.GetComponent<Button>();
        button.onClick.AddListener(IncrementValue);
    }
    void Update()
    {
        BarDecrease();
        BarChange(_value);
    }
    void BarDecrease()
    {
        _value -= DecreaseRate * Time.deltaTime; // Decrease the value over time
        if (_value < 0)
        {
            _value = 0;
            DecreaseRate = 10f;
        }
    }
    void BarChange(float Value)
    {
        float amount = Value / 100.0f;
        Bar.fillAmount = amount;
        float buttonAngle = amount * 360;
        ButtonContainer.localEulerAngles = new Vector3(0, 0, -buttonAngle);
    } 

    void IncrementValue()
    {
        _value = _value + IncreaseValueBy;
        ScaleUpDown(gameObject);
        if (_value >= 100)
        {
            _stage++;
            Debug.Log(_stage);
            _value = 100;
            DecreaseRate = 100f;
        }
        if (_stage>=5)
        {
            Destroy(gameObject);
        }
    }

    void ScaleUpDown(GameObject Go)
    {
        LeanTween.scale(Go, new Vector3(BounceScale * 8, BounceScale * 8, BounceScale * 8), BounceDuration / 2f)
            .setEaseInOutSine()
        .setOnComplete(ScaleDown);
        void ScaleDown()
        {
            LeanTween.scale(Go, new Vector3(8f, 8f, 8f), BounceDuration / 2f)
                .setEaseInOutSine();
        }
    }
}