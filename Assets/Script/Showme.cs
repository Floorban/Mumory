using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showme : MonoBehaviour
{
    public GameObject pic;
    // Start is called before the first frame update
    void Start()
    {
        pic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Clicked()
    {
        pic.SetActive(true);
    }
}
