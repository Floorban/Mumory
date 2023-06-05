using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerNPCUi : MonoBehaviour
{   
    private GameObject objPlayer;
    public Image prefabUi;
    private Image uiUse;   
    //private Transform tr_head;
    public Vector3 offset = new Vector3(0, 1.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        objPlayer = GameObject.FindGameObjectWithTag("Player");
        uiUse =  Instantiate(prefabUi, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        //tr_head = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        uiUse.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset); 

        float dist = 1 / Vector3.Distance(transform.position, objPlayer.transform.position) * 8f;
        dist = Mathf.Clamp(dist, 0.1f, 2f);
        uiUse.transform.localScale = new Vector3(dist, dist, 0);
    }
    
}
