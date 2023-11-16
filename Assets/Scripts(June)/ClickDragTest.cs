using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragTest : MonoBehaviour
{
    public bool autoReturn = true;


    public bool dragging = false;

    //offset to compensate for mouse clicking being weird
    Vector3 mousePositionOffset;


    //Stores the position something's at when you click it
    private Vector3 lastValidCoords;

    //[SerializeField] GameObject cookingPot; 

    // Start is called before the first frame update
    void Start()
    {
        lastValidCoords = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mousePositionOffset;
        }
    }

    public bool isBeingDragged()
    {
        return dragging;
    }


    private void OnMouseDown()
    {
        //"Grabs" what you're hovering over

        //Stores start position
        //lastValidCoords = transform.position;
        mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }


    private void OnMouseDrag()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mousePositionOffset;
        }
    }

    private void OnMouseUp()
    {
        if (autoReturn)
        {
            transform.position = lastValidCoords;
            
        }
        dragging = false;
    }

    public void resetPosition()
    {
        transform.position = lastValidCoords;
    }
    //sets lastValidCoords to the passed position: called from other scripts
    //need some signal-based variant for transitions, work on when working on screen transition
    public void setHome(Vector3 newHome)
    {
        lastValidCoords = newHome;
    }


    public void startDrag()
    {
        //mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);// + mousePositionOffset;
        //mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //lastValidCoords = transform.position;
        mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lastValidCoords = transform.position;

        dragging = true;
        
    }
}
