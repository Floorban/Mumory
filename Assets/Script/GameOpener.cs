using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Text;
    public GameObject Button;

    private void Start()
    {
        Button.SetActive(false);
        Panel.SetActive(false);
        Text.SetActive(false);
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Button.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Button.SetActive(false);
            Panel.SetActive(false);
             Text.SetActive(false);
        }
    }

    public void OpenPanel()
    {

            Panel.SetActive(true);
            Text.SetActive(true);


    }
}
