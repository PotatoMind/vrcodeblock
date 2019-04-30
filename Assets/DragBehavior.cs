using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBehavior : MonoBehaviour
{
    public Color draggingColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
 
    void Start() 
    {
        originalColor = GetComponent<Renderer>().material.color;
    }
 
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        GetComponent<Renderer>().material.color = draggingColor;
        dragging = true;
    }
 
    void OnMouseUp()
    {
        GetComponent<Renderer>().material.color = originalColor;
        dragging = false;
    }
 
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}
