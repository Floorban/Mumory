using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenerController : MonoBehaviour
{
    public GameObject Photo;
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;

    public GameObject ButtonOpen;
    public GameObject ButtonClose;

     private bool isFinished;

     public CameraFollow camerafollow;
    private Vector3 initialOffset;
    
     
    private void Start() 
    {
        isFinished = true;
        CameraFollow offset = GetComponent<CameraFollow>();
        initialOffset = camerafollow.offset;
        ButtonClose.SetActive(false);
        ButtonOpen.SetActive(false);
            
    }
    
    private void Update()
    {
        

        if (isFinished == false)
        {
            Photo.SetActive(true);
        }
        else
        {
            Photo.SetActive(false);
            ButtonClose.SetActive(false);
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
            ButtonClose.SetActive(false);
        }
        
    }

    public void BeginDialogue()
    {
         camerafollow.offset = new Vector3(0, 10, 0);
            isFinished = false;
            DialogueAnimator.SetTrigger("Enter");
            ButtonOpen.SetActive(false);
            ButtonClose.SetActive(true);
            NextSentence();
            

  
    }
    public void NextSentence()
    {
       
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
