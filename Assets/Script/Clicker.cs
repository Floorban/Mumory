using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour
{
    public GameObject clickedObj;

    public GameObject pic;

    private void Start() 
    {
        pic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickedObj == GetClickedObject(out RaycastHit hit))
            {
                Debug.Log("rinima");
                pic.SetActive(true);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("888");
            pic.SetActive(false);
        }
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
        {
            if (!IsPointerOverUIObject())
            {
                target = hit.collider.gameObject;
            }
        }

        return target;
    }

    bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
