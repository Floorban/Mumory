using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QTE2Script : MonoBehaviour
{
    public Health health;
    public GameObject Joystick;
    public Image Bar;

     public Animator DialogueAnimator;

    public CameraFollow camerafollow;
    public RectTransform ButtonContainer;
    public float _value;
    public float DecreaseRate;
    public float IncreaseValueBy;
    public float BounceDuration;
    public float BounceScale;
    public int _stage = 1;
    private Transform canvasP;
    public delegate void VictoryEventHandler(bool value);
    public static event VictoryEventHandler OnBoolValueChanged;
    public delegate void ShakeAction();
    public static event ShakeAction OnShake;
    bool VictoryValue = true;
    private bool hashappened = false;
    bool WinPoints = false;
    public TMP_Text TextSwitch;
    private GameObject Background;
    private GameObject ButtonObject;
    private GameObject TextObject;
    // Subscribe to the OnStageChange event
    private void OnEnable()
    {
        QTE2Activator.OnStageChange += HandleStageChange;
        QTE2Activator.OnEventHappened += HandleEventHappened;
    }

    // Unsubscribe from the OnStageChange event
    private void OnDisable()
    {
        QTE2Activator.OnStageChange -= HandleStageChange;
        QTE2Activator.OnEventHappened -= HandleEventHappened;
    }
    private void HandleStageChange(int newStage)
    {
        _stage = newStage;
        // Handle the new stage value as needed
    }
    private void HandleEventHappened(bool value)
    {
        hashappened = value;
        // Handle the new value as needed
    }

    private Vector3 initialOffset;

    private void Start()
    {
        Joystick.SetActive(false);
        Background = GameObject.Find("Background");
        TextObject = GameObject.Find("TextObject");
        canvasP = GameObject.Find("Canvas").GetComponent<Transform>();
        ButtonObject = GameObject.Find("ButtonClick");
        Transform ButtonClick = transform.Find("ButtonClick");
        Button button = ButtonClick.GetComponent<Button>();
        button.onClick.AddListener(IncrementValue);

        Health Heal = GetComponent<Health>();
        Health Damage = GetComponent<Health>();

        CameraFollow offset = GetComponent<CameraFollow>();
         initialOffset = camerafollow.offset;
    }
    void Update()
    {
        BarDecrease();
        BarChange(_value);
        ResetAtZero();
        StageHandler();

    }
    void BarDecrease()
    {
        _value -= DecreaseRate * Time.deltaTime;
        Joystick.SetActive(false);
        camerafollow.offset = new Vector3(0, 10, 0); // Decrease the value over time
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
    ScaleUpDown(ButtonObject);
    ScaleUpDown(Background);
    if (_value >= 100)
    {
        _stage++;
            hashappened = false;
            Debug.Log(_stage);
        //ResetValueTo(40);
        DecreaseRate = 100f;
        WinPoints = false;
        // Apply health damage when value reaches 100
        health.Damage(10f);
    }

}
    void ResetValueTo(float resetValue)
    {
        _value = resetValue;
    }   
    void ResetAtZero()
    {
        if (_value <= 0)
        {
            _stage++;
            hashappened = false;
            WinPoints = true;
        Debug.Log(_stage);
        DecreaseRate = 100f;
        _value = 40;
        OnShake();
        // Apply health damage when value reaches 100
        health.Heal(10f);
        }
         if (_value <= 40)
         {
           DecreaseRate = 15f;
         }
    }
    void StageHandler(){
        if (hashappened == false)
        {
            //camerafollow.offset = new Vector3(0, 10, 0);
            switch(_stage){
                case 1:
                    hashappened = true;
                    DialogueAnimator.SetTrigger("Enter");
                    TextSwitch.enabled = true;
                    TextSwitch.text = "Clean the room Aletta!";
                break;
                case 2:
                hashappened = true;
                if (WinPoints)
                {
                    TextSwitch.text = "Come on! Don't you dare do that again!";

                }
                else
                {
                    TextSwitch.text = "Yes! That's how it should be done!";
                }
                break;
                case 3:
                hashappened = true;
                if (WinPoints){
                    TextSwitch.text = "Come on! Don't you dare do that again!";
                }
                else
                {
                    TextSwitch.text = "Yes! That's how it should be done!";
                }
                break;
                case 4:
                if (WinPoints)
                {
                    TextSwitch.text = "Come on! Don't you dare do that again!";
                }
                else
                {
                    TextSwitch.text = "Yes! That's how it should be done!";
                }
                hashappened = true;
                break;
                case 5:
                hashappened = true;
                DialogueAnimator.SetTrigger("Exit");
                    TextSwitch.enabled = false;
                    Joystick.SetActive(true);
                OnBoolValueChanged?.Invoke(VictoryValue);
                    ResetOffset();
                    this.gameObject.SetActive(false);
                break;
                default:
                Debug.Log("Invalid stage: " + _stage);
                
                break;
            }
        }
    }

    void ScaleUpDown(GameObject Go)
    {
        LeanTween.scale(Go, new Vector3(BounceScale, BounceScale, BounceScale), BounceDuration / 2f)
            .setEaseInOutSine()
        .setOnComplete(ScaleDown);
        void ScaleDown()
        {
            LeanTween.scale(Go, new Vector3(1f, 1f, 1f), BounceDuration / 2f)
                .setEaseInOutSine();
        }
    }
    
    public void ResetOffset()
    {
         //Reset the camera offset to its initial value
        camerafollow.offset = initialOffset;
        DialogueAnimator.SetTrigger("Exit");
    }
}
