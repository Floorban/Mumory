using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Health health;

    [SerializeField] private Image _bar;
    [SerializeField] private Image _highlight;
    [SerializeField] private Image _button;
    private float _buttonpos;
    private float _highlightposmin;
    private float _highlightposmax;
    private float _value = 0;
    public float speed = 3f;
    public RectTransform ButtonContainer;
    public bool isActive = true;
    private bool Scored;
    private int CurrentStage;
    bool hasStopped = false;
    private GameObject MainBody;
    private GameObject compartment1Pass;
    private GameObject compartment1Fail;
    private GameObject compartment2Pass;
    private GameObject compartment2Fail;
    private GameObject compartment3Pass;
    private GameObject compartment3Fail;
    private GameObject compartment4Pass;
    private GameObject compartment4Fail;
    void Start()
    {
        CurrentStage = 1;
        MainBody = GameObject.Find("progressbar");
        GameObject compartment1 = GameObject.Find("Compartment1");
        GameObject compartment2 = GameObject.Find("Compartment2");
        GameObject compartment3 = GameObject.Find("Compartment3");
        GameObject compartment4 = GameObject.Find("Compartment4");
        compartment1Pass = FindChildrenWithTag(compartment1, "Pass");
        compartment1Fail = FindChildrenWithTag(compartment1, "Fail");
        compartment2Pass = FindChildrenWithTag(compartment2, "Pass");
        compartment2Fail = FindChildrenWithTag(compartment2, "Fail");
        compartment3Pass = FindChildrenWithTag(compartment3, "Pass");
        compartment3Fail = FindChildrenWithTag(compartment3, "Fail");
        compartment4Pass = FindChildrenWithTag(compartment4, "Pass");
        compartment4Fail = FindChildrenWithTag(compartment4, "Fail");

         Health Heal = GetComponent<Health>();
         Health Damage = GetComponent<Health>();
    }
    private GameObject FindChildrenWithTag(GameObject parent, string tag)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }

        return null;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            isActive = true;
        }
        
        if (isActive == true)
        {
            Randomizer();
            StartCoroutine(ActiveBar(_value, 100, speed));
        }
        BarChange(_value);
    }

    void BarChange(float Value)
    {
        float amount = (Value / 100.0f);
        _bar.fillAmount = amount;
        float buttonAngle = amount * 360;
        ButtonContainer.localEulerAngles = new Vector3(0, 0, -buttonAngle);
        _buttonpos = ButtonContainer.localRotation.eulerAngles.z;
        //_buttonpos = _button.GetComponent<RectTransform>()
    }

    void ResetBar()
    {
        _value = 0;
        isActive = true;
    }

    void StageSetter()
    {
        switch (CurrentStage)
        {
            case 1:
                if (Scored)
                {
                    SetActiveForCompartment(compartment1Pass);
                    //Debug.Log("Scored" + Score);

                        health.Heal(10f);
        
                }
                else
                {
                    SetActiveForCompartment(compartment1Fail);
                    //Debug.Log("Missed" + Score);
                    
                        health.Damage(10f);
                    
                }
                break;
            case 2:
                if (Scored)
                {
                    SetActiveForCompartment(compartment2Pass);
                    

                        health.Heal(10f);
                }
                else
                {
                    SetActiveForCompartment(compartment2Fail);
                    
                        health.Damage(10f);
                }
                break;
            case 3:
                if (Scored)
                {
                    SetActiveForCompartment(compartment3Pass);

                        health.Heal(10f);
                }
                else
                {
                    SetActiveForCompartment(compartment3Fail);
                    
                        health.Damage(10f);
                }
                break;
            case 4:
                if (Scored)
                {
                    SetActiveForCompartment(compartment4Pass);

                        health.Heal(10f);
                }
                else
                {
                    SetActiveForCompartment(compartment4Fail);
                    
                        health.Damage(10f);
                }
                break;
            default:
                Debug.Log("Invalid stage: " + CurrentStage);
                break;
        }
        CurrentStage++;
        
    }
    private void SetActiveForCompartment(GameObject Compartment)
    {
        Compartment.gameObject.SetActive(true);
    }
    void Randomizer()
    {
        float fillAmount = Random.Range(0.1f, 0.15f);
        float rotation = Random.Range(180f, 270f);
        _highlight.fillAmount = fillAmount;
        _highlight.rectTransform.rotation = Quaternion.Euler(0f, 0f, rotation);
        _highlightposmin = rotation;
        _highlightposmax = rotation - (360 * fillAmount);
    }

    public IEnumerator ActiveBar(float oldValue, float newValue, float duration)
    {
        if (CurrentStage >= 5)
        {
            Destroy(MainBody);
        }

        isActive = false;
        Debug.Log("Current stage: " + CurrentStage);
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            _value = Mathf.Lerp(oldValue, newValue, t / duration);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasStopped = true;
                break;
            }
            yield return null;
        }
        /* Debug the rotation positions of button or highlight start
         * Debug.Log("Button position:" + _buttonpos);
        Debug.Log("Highlight position: " + _highlightposmin);*/

        if (_value >= 90)
        {
            hasStopped = true;

            //ResetBar(); probably in the future
        }
        if (hasStopped)
        {
            if (_buttonpos <= _highlightposmin && _buttonpos >= _highlightposmax)
            {
                Scored = true;
                
            }
            else
            {
                Scored = false;
                
            }
        }
        StageSetter();
        System.Threading.Thread.Sleep(500); // wait for 1 sec
        hasStopped = false;
        ResetBar();
    }
}

