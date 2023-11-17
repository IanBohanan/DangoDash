using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class dayManager : MonoBehaviour
{
    public static event Action dayReset; //Sent out when the day is fully reset

    //Keep track of the day stats
    private int drinksServed = 0;
    private int customersServed = 0;
    private int customersCameIn = 0; //How many customers came into the store?
    private int foodMade = 0;
    private int daysCompleted = 0;

    //All the texts to change on the data screen
    [SerializeField]
    private TMP_Text totalCustomersText;
    [SerializeField]
    private TMP_Text happyCustomersText;
    [SerializeField]
    private TMP_Text sadCustomersText;

    [SerializeField]
    private RepBar repBar; //The reputation bar object that contains the reputation to check
    private int curReputation; //The reputation at the end of the day 
    private int startReputation; //The reputation at the beginning of the day
    [SerializeField]
    private TMP_Text reputationText;

    [SerializeField]
    private GameObject endOfDayScreen;


    private void Start()
    {
        startReputation = repBar.reputation;
    }

    // Subscribe to all the events to watch
    void OnEnable()
    {
        StardewClock.dayOver += endDay; //
        Customer.customerLeft += servedCustomer;
        cookingPot.outputFood += createdFood;
    }

    void OnDisable()
    {
        StardewClock.dayOver -= endDay;
        Customer.customerLeft -= servedCustomer;
        cookingPot.outputFood -= createdFood;
    }

    //Once the day is over (triggered by end of clock) then update the data screen with the current variables
    //Then show the data to the player
    void endDay()
    {
        totalCustomersText.text = customersCameIn.ToString();
        happyCustomersText.text = customersServed.ToString();
        sadCustomersText.text = (customersCameIn - customersServed).ToString();

        curReputation = repBar.reputation; //Get the current reputation to compare

        if(curReputation >= startReputation) //Player was able to end with more or equal reputation than they did yesterday!
        {
            reputationText.color = new Color(0, 173/255f, 26/255f, 1); //Change color to green
            reputationText.text = curReputation.ToString() + " (+" + (curReputation-startReputation).ToString() + ")";
        }
        else //Player ended with less reputation than yesterday
        {
            reputationText.color = new Color(173 / 255f, 11 / 255f, 0, 1); //Change color to red
            reputationText.text = curReputation.ToString() + " (-" + (curReputation - startReputation).ToString() + ")";
        }
        daysCompleted++;
        endOfDayScreen.SetActive(true);
        resetVars();
    }

    //Resets all variables to their start values
    private void resetVars()
    {
        startReputation = repBar.reputation;
        drinksServed = 0;
        customersServed = 0;
        customersCameIn = 0; //How many customers came into the store?
        foodMade = 0;
        daysCompleted = 0;
    }

    void createdFood(foodName food)
    {
        foodMade++;
    }

    void servedCustomer(bool wasHappy)
    {
        customersCameIn++;
        if(wasHappy)
        {
            customersServed++;
        }
    }

    public void restartDay()
    {
        dayReset?.Invoke();
        endOfDayScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
