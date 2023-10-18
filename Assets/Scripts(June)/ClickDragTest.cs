using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragTest : MonoBehaviour
{


    private bool dragging = false;

    //offset to compensate for mouse clicking being weird
    Vector3 mousePositionOffset;


    //Stores the position something's at when you click it
    Vector3 startingPosition = Vector3.zero;

    //[SerializeField] GameObject cookingPot; 

    // Start is called before the first frame update
    void Start()
    {
        
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
        startingPosition = transform.position;
        mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        dragging = true;
    }


    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mousePositionOffset;



    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    public void resetPosition()
    {
        print("tried resetting");
        transform.position = startingPosition;
    }
}



/*Questions for meeting
 * 
 * what do if player tries to cook when all storage spots are full?
 * whad do if player tries to drop an object in the completely wrong place
 * snapping to location when dropped?
 * */