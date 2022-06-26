using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndScale : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    Vector2 move = Vector2.zero;
    float scale = 0.001f;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 Scale = new Vector3(transform.localScale.x * (1 + scale), transform.localScale.y * (1 + scale), 1);
            transform.localScale = Scale;
        }
        if (Input.GetKey(KeyCode.X))
        {
            Vector3 Scale = new Vector3(transform.localScale.x / (1 + scale), transform.localScale.y / (1 + scale), 1);
            transform.localScale = Scale;
        }
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        mousePos = Input.mousePosition;
        move = transform.position;
    }

    /// <summary>
    /// OnMouseDrag is called when the user has clicked on a GUIElement or Collider
    /// and is still holding down the mouse.
    /// </summary>
    void OnMouseDrag()
    {
        Debug.Log("Drag");

        Vector2 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = new Vector3(move.x + offset.x, move.y + offset.y, transform.position.z);
    }
}
