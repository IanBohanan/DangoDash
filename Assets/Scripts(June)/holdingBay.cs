using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdingBay : MonoBehaviour
{

    public GameObject containedItem;

    public bool canChange; //Is this holding bay allowed to change during gameplay? Or should it remain the same?

    //checks if you are currently collided with an object
    public bool collided;

    holdingBay collidedBay;


    //Once player drops the item on this object, send the held item to the connected holding bay (if it is supposed to hold multiple items)
    private void OnMouseUp()
    {
        if (collided && collidedBay.canChange)
        {
            sendObject(collidedBay);
        }
    }
    
    //Whenever this collides with another object, check to see if it have a holding bay.
    //If so, connect these two holding bays together so they can transfer to each other.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            collidedBay = collision.gameObject.GetComponent<holdingBay>();
            collided = true;
        }
        catch (Exception a) { }
    }

    //When collision ends, undock from the other holding bay.
    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
        collidedBay = null;
    }
    
    //Send object to the other holdingbay
    public void sendObject(holdingBay receivingBay)
    {
        receivingBay.receiveObject(containedItem);
    }

    public void receiveObject(GameObject sentObject)
    {
        containedItem = sentObject;
    }

    public void clearBay()
    {
        containedItem = null;
    }

}