using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepBar : MonoBehaviour
{

    private Slider slider;  //The visible slider component of the reputation bar
    public int reputation = 100;


    //When object created (and enabled) subscribe to the customer's leaving
    private void OnEnable()
    {
        Customer.customerLeft += onCustomerLeave;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
        updateSlider();
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
            reputation += 10;
        }
        else
        {
            reputation -= 10;
        }
        updateSlider();
    }

    //Updates the value in the slider so it matches the current reputation
    private void updateSlider()
    {
        slider.value = reputation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
