using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableWall : MonoBehaviour, IDragHandler
{

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragged");
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Debug.Log("dragged");
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = temp;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
