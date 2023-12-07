using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class dayManager : MonoBehaviour
{
    public static event Action dayReset; //Sent out when the day is fully reset

    //Keep track of the day stats
    private int drinksServed = 0;
    private int customersServed = 0;
    private int customersCameIn = 0; //How many customers came into the store?
    private int foodMade = 0;
    //Keep track of lifetime stats
    private int daysCompleted = 0;
    private int lifeServedCustomers = 0;
    private int lifeAngeredCustomers = 0;
    private int lifeFoodCooked = 0;
    private int lifeTrashCount = 0;

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

    [Header("Text bars game over screen")]
    [SerializeField]
    private TMP_Text lifetimeServedText;
    [SerializeField]
    private TMP_Text lifetimeAngeredText;
    [SerializeField]
    private TMP_Text daysInServiceText;
    [SerializeField]
    private TMP_Text foodCookedText;
    [SerializeField]
    private TMP_Text trashMadeText;
    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]private CustomerSpawner customerSpawner;


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
        RepBar.gameOver += endGame;
    }

    void OnDisable()
    {
        StardewClock.dayOver -= endDay;
        Customer.customerLeft -= servedCustomer;
        cookingPot.outputFood -= createdFood;
        RepBar.gameOver -= endGame;
    }

    private void endGame()
    {
        lifetimeServedText.text = lifeServedCustomers.ToString();
        lifetimeAngeredText.text = lifeAngeredCustomers.ToString();
        daysInServiceText.text = daysCompleted.ToString();
        foodCookedText.text = lifeFoodCooked.ToString();
        trashMadeText.text = lifeTrashCount.ToString();

        gameOverScreen.SetActive(true);
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

        //Add to lifetime stats before resetting
        lifeServedCustomers += customersServed;
        lifeAngeredCustomers += customersCameIn - customersServed;
        float customerSatisfactionPercent = (customersServed / customersCameIn) * 100;
        resetVars();

        //Then adjust difficulty for the next day. 
        //If the player was able to get at least 75% correct customers served, then increase the minimum reputation
        if (customerSatisfactionPercent >= 50)
        {
            
            //if player was able to manage stated happy rating, increase the difficulty!
            IncreaseDifficulty();
        }
        //Else do not increase difficulty
    }

    //Increases the difficulty for the next day.
    private void IncreaseDifficulty()
    {

        repBar.increaseMinReputation(10); //Increases minimum reputation by flat amount
        customerSpawner.increaseDifficulty();
    }

    //Resets all variables to their start values
    private void resetVars()
    {
        startReputation = repBar.reputation;
        drinksServed = 0;
        customersServed = 0;
        customersCameIn = 0; //How many customers came into the store?
        foodMade = 0;
    }

    void createdFood(foodName food)
    {
        if(food == foodName.TRASH)
        {
            lifeTrashCount++;
        }
        else
        {
            foodMade++;
            lifeFoodCooked++;
        }
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

    public void returnToMenu()
    {
        SceneManager.LoadScene("TitleTentative");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
