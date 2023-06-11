using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerNPCUi : MonoBehaviour
{   
    private GameObject objPlayer;
    public Image prefabUi;
    private Image uiUse;   
    private bool imageDisabled = false;
    private const float maxClosestDistance = 4.5f;
    public Vector3 offset = new Vector3(0, 1.5f, 0);
    private void OnEnable(){
        QTE2Activator.OnButtonPress += OnButtonPress;
    }
    private void OnDisable(){
        QTE2Activator.OnButtonPress -= OnButtonPress;
    }
    private void OnButtonPress()
    {

        Transform playerTransform = objPlayer.transform;
        float closestDistance = Mathf.Infinity;
        Image closestImage = null;
        imageDisabled = false;
        foreach (ManagerNPCUi npcUi in FindObjectsOfType<ManagerNPCUi>())
        {
            if (npcUi != this)
            {
                float distance = Vector3.Distance(npcUi.transform.position, playerTransform.position);
                if (distance < closestDistance && distance <= maxClosestDistance && !npcUi.imageDisabled)
                {
                    closestDistance = distance;
                    closestImage = npcUi.uiUse;
                }
            }
        }
        if (closestImage != null && !imageDisabled)
        {
            closestImage.enabled = false;
            imageDisabled = true;
            return;
        }
    }
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
