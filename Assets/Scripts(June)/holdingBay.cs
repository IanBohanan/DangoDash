using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdingBay : MonoBehaviour
{

   public GameObject containedItem;

    //checks if you are currently collided with an object
    bool collided;

    holdingBay collidedBay;

    // Start is called before the first frame update
    void Start()
    {
        print("I exist");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
        
        if (collided)
        {

            print("OnMouseUp Proper");

            sendObject(collidedBay);
        }
        

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
        try
        {
            collidedBay = collision.gameObject.GetComponent<holdingBay>();
            
            collided = true;
            print("got collidedBay");
        }
        catch (Exception a) { }

        
        
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        print("collision exit");

        collided = false;
    }

    public void sendObject(holdingBay receivingBay)
    {
        print("sendingObject");

        receivingBay.receiveObject(containedItem);
    }

    public void receiveObject(GameObject sentObject)
    {

        print("receivingObject");
        containedItem = sentObject;

    }

    public void clearBay()
    {
        containedItem = null;
    }

}