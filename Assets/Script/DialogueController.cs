using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;

    public GameObject ButtonOpen;
    public GameObject ButtonContinue;
     
    private void Start() 
    {

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
