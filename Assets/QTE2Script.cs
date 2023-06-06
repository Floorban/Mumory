using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE2Script : MonoBehaviour
{
    public GameObject Joystick;
    public Image Bar;
    public RectTransform ButtonContainer;
    public float _value;
    public float DecreaseRate;
    public float IncreaseValueBy;
    public float BounceDuration;
    public float BounceScale;
    private int _stage = 1;
    public GameObject WinCondition;
    public GameObject LoseCondition;
    private Transform canvasP;
    QTE2Activator Instance = new QTE2Activator();
    private void Start()
    {
        Joystick.SetActive(false);
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
            DecreaseRate = 15f;
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
            Joystick.SetActive(true);
            _stage = 1;
            Instance.QTE2Victory();
            this.gameObject.SetActive(false);
        }
    }

    void ScaleUpDown(GameObject Go)
    {
        LeanTween.scale(Go, new Vector3(BounceScale * 3, BounceScale * 3, BounceScale * 3), BounceDuration / 2f)
            .setEaseInOutSine()
        .setOnComplete(ScaleDown);
        void ScaleDown()
        {
            LeanTween.scale(Go, new Vector3(3f, 3f, 3f), BounceDuration / 2f)
                .setEaseInOutSine();
        }
    }
}