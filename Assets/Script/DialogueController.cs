using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;

    public GameObject ButtonOpen;
    public GameObject ButtonContinue;

     public GameObject Joystick;

     private bool isFinished;

     public CameraFollow camerafollow;
      private Vector3 initialOffset;
    
     
    private void Start() 
    {
        isFinished = true;
         CameraFollow offset = GetComponent<CameraFollow>();
        initialOffset = camerafollow.offset;
    }
    
    private void Update()
    {
        if (Index >= 0 && Index < Sentences.Length)
        {
            if (DialogueText.text == Sentences[Index])
            {
                ButtonContinue.SetActive(true);
            }
        }

        if (isFinished == false)
        {
            Joystick.SetActive(false);
        }
        else
        {
            Joystick.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            ButtonOpen.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            ButtonOpen.SetActive(false);
            ButtonContinue.SetActive(false);
        }
        
    }

    public void BeginDialogue()
    {
         camerafollow.offset = new Vector3(0, 10, 0);
            isFinished = false;
            DialogueAnimator.SetTrigger("Enter");
            ButtonOpen.SetActive(false);
            ButtonContinue.SetActive(true);
            NextSentence();
  
    }
    public void NextSentence()
    {
        ButtonContinue.SetActive(false);
        if (Index <= Sentences.Length - 1)
        {
            
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            DialogueText.text = "";
            DialogueAnimator.SetTrigger("Exit");
            Index = 0;
            ButtonContinue.SetActive(false);
            isFinished = true;
             camerafollow.offset = initialOffset;
        }
    }

    IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        Index++;
    }
}
