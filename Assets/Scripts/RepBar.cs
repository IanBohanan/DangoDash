using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RepBar : MonoBehaviour
{
    public static event Action gameOver; //Sent out when reputation reached zero
    private Slider slider;  //The visible slider component of the reputation bar
    [SerializeField] private Slider minRepSlider; //The red slider that shows min reputation required
    public int reputation = 100;
    public int minreputation = 0; //The minimum reputation required before gameOver.

    //makes the silly little cat sounds to indicate their satisfaction
    [SerializeField] AudioSource catsMeow;

    [SerializeField] AudioClip happyCat;

    [SerializeField] AudioClip sadCatTwT;


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

    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
        updateSlider();
    }


    //Triggered when a customer leaves the restraunt.
    //Params: bool wasHappy - was the customer satisfied when they left?
    private void onCustomerLeave(bool wasHappy)
    {
        if(wasHappy)
        {
            if(reputation < 100)
            {
                reputation += 10;
            }
            

            catsMeow.clip = happyCat;
            catsMeow.Play();
        }
        else
        {
            reputation -= 10;
            catsMeow.clip = sadCatTwT;
            catsMeow.Play();
        }
        updateSlider();
    }

    //Updates the value in the slider so it matches the current reputation
    private void updateSlider()
    {
        slider.value = reputation;

        if(reputation < minreputation)
        {
            gameOver?.Invoke();
        }

    }

    //Increases the minimum reputation needed to continue and updates the slider
    //Note: it caps minimum reputation at 75% of the rep bar. This is for balancing reasons
    public void increaseMinReputation(int amountToIncrease)
    {
        print("RepBar: Min reputation increased!");
        if(minreputation < 75)
        {
            minreputation += amountToIncrease;
            //Then update the slider
            minRepSlider.value = minreputation;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
