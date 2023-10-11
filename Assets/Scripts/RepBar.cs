using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepBar : MonoBehaviour
{

    public int reputation = 100;


    //When object created (and enabled) subscribe to the customer's leaving
    private void OnEnable()
    {
        Customer.customerLeft += onCustomerLeave;
    }

    //When object created (and enabled) unsubscribe to the customer when they left
    //Very important or else errors will happen!
    private void OnDisable()
    {
        Customer.customerLeft -= onCustomerLeave;
    }

    //Triggered when a customer leaves the restraunt.
    //Params: bool wasHappy - was the customer satisfied when they left?
    private void onCustomerLeave(bool wasHappy)
    {
        if(wasHappy)
        {
            print("RepBar: Customer left restraunt! They were happy so reputation increased!");
            reputation += 10;
        }
        else
        {
            print("RepBar: Customer left restraunt! They were happy so reputation dropped!");
            reputation -= 10;
        }
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
