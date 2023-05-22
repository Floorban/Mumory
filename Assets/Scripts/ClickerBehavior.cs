using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ClickerBehavior : MonoBehaviour
{
    public Image Bar;
    public RectTransform ButtonContainer;
    [SerializeField] private TextMeshProUGUI _countdowntext;
    private float _value = 0;
    public float IncreaseValueBy = 1f;
    public float BounceDuration = 0.2f;
    public float BounceScale = 1.2f;
    private float _currentTime = 0f;
    public float StartingTime = 10f;
    public bool OnOffAtStart = true;
    GameObject ButtonObject;
    private void Start()
    {
        ButtonObject = GameObject.Find("ButtonClick");
        _currentTime = StartingTime;
        Transform ButtonClick = transform.Find("ButtonClick");
        Button button = ButtonClick.GetComponent<Button>();
        button.onClick.AddListener(IncrementValue);
        if (OnOffAtStart == false)
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        BarChange(_value);
        Timer();
    }
    void BarChange(float Value)
    {
        float amount = Value / 100.0f;
        Bar.fillAmount = amount;
        float buttonAngle = amount * 360;
        ButtonContainer.localEulerAngles = new Vector3(0, 0, -buttonAngle);
    } 
    void Timer()
    {
        _currentTime -= 1 * Time.deltaTime;
        _countdowntext.text = _currentTime.ToString("0.0");
        if (_currentTime <= 5)
        {
            float t = Mathf.InverseLerp(1, 5, _currentTime);
            _countdowntext.color = Color.Lerp(Color.red, Color.white, t);
        }
        if (_currentTime <= 0)
        {
            Debug.Log("Failure! Ran out of time.");
            Destroy(gameObject);
        }
    }
    void IncrementValue()
    {
        _value = _value + IncreaseValueBy;
        Debug.Log("Value increased to " + _value);
        ScaleUpDown(gameObject);
        if (_value >= 100)
        {
            Debug.Log("Winner winner chicken dinner!");
            Destroy(gameObject);
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
}
