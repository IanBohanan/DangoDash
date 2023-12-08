using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    //All the slides and tutorial UI to enable/Disable

    [SerializeField] private GameObject startSlide;
    [SerializeField] private GameObject KitchenSlide;
    [SerializeField] private GameObject DrinkSlide;
    [SerializeField] private GameObject SpaceSlide;
    [SerializeField] private GameObject firstCustSlide;
    [SerializeField] private GameObject WrongServeSlide;
    [SerializeField] private GameObject CorrectServeSlide;
    [SerializeField] private GameObject RepBarSlide;
    [SerializeField] private GameObject finalSlide;
    [SerializeField] private GameObject KitchenArrow;
    [SerializeField] private GameObject DrinkArrow;
    [SerializeField] private GameObject ClockArrow;
    [SerializeField] private GameObject RepArrow;
    [SerializeField] private GameObject Clock;
    [SerializeField] private GameObject RepBar;

    [SerializeField] private GameObject customerPrefab; //The customer prefab to spawn
    [SerializeField] private Transform customerLocation;

    [SerializeField] private GameObject kitchenArea;
    [SerializeField] private GameObject drinkArea;

    public enum Stages
    {
        Start, //Player reads start message
        WaitForKitchen, //Player is freely exploring the cafe. Kitchen arrow pointing to door
        ReadingKitchen, //Player is reading the text box in the kitchen
        MixingWhatever, //Player is messing around in the kitchen.
        WaitForDrinks, //Player in restraunt with arrow pointing to drink mixer
        ReadingDrinks, //Player reading slide in drink station
        DrinkingWhatever, //Player is messing around in the drink station
        LearningSpaceLimitation, //Player is reading slide about limited space.
        LearningCustomers, //Player is reading slide about customer dragging
        FirstCustomerArrives, //First customer has appeared
        CustomerSatDown, 
        CustomerFedWrong, //Customer was fed wrong! Player reading wrong slide
        CustomerSuccessShowClock, //Customer was fed right! Player reading correct slide
        ReadRepbar, //Player reading about repBar
        ReadFinal //Player finishing final slide
    }

    public Stages curStage = Stages.Start;

    public float readTime = 1.0f; //Minimmum amount of time before player is allowed to click through

    public bool isReading = true; //Is the player reading a slide? If so, then allow them to click to the next stage

    public bool customerSatisfied = false;

    private void OnEnable()
    {
        Customer.leftLine += leftLine;
        Customer.customerLeft += leftRestraunt;
        exitButtonCookingArea.kitchenAreaClosed += closedKitchenOrDrinks;
        KitchenDoor.kitchenAreaOpened += openedKitchen;
        overworldJuiceM.drinkAreaOpened += openedDrinks;
    }

    private void OnDisable()
    {
        Customer.leftLine -= leftLine;
        Customer.customerLeft -= leftRestraunt;
        exitButtonCookingArea.kitchenAreaClosed -= closedKitchenOrDrinks;
        KitchenDoor.kitchenAreaOpened -= openedKitchen;
    }

    //Triggered when tutorial customer was fed
    public void fedCustomers(bool wasHappy)
    {
        print("TutorialManager: Customer happy was " + wasHappy);
        customerSatisfied = wasHappy;
        goToNextStage();
    }

    private void openedKitchen()
    {
        if(curStage == Stages.WaitForKitchen)
        {
            goToNextStage();
        }
    }

    private void openedDrinks()
    {
        print("TutorialManager: Drinks opened!");
        if(curStage == Stages.WaitForDrinks)
        {
            print("TutorialManager: Showing tutorial stage for drinks");
            goToNextStage();
        }
    }

    private void resetReadTime()
    {
        readTime = 1.0f;
    }

    // Either the kitchen or drinks were closed. Either one could have applied so gonna have to perform some checks
    private void closedKitchenOrDrinks()
    {
        if(curStage == Stages.MixingWhatever && kitchenArea.activeInHierarchy)
        {
            goToNextStage();
        }
        else if(curStage == Stages.DrinkingWhatever && drinkArea.activeInHierarchy)
        {
            goToNextStage();
        }
    }

    private void OnMouseDown()
    {


    }

    private void leftLine(int ignoreMe)
    {
        goToNextStage();
    }

    private void leftRestraunt(bool wasHappy)
    {
        customerSatisfied = wasHappy;
        goToNextStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (readTime > 0)
        {
            readTime -= Time.deltaTime;
        }

        //Try to go to next slide if mousebutton clicked
        if(Input.GetMouseButtonDown(0))
        {
            if (readTime <= 0 && isReading)
            {
                goToNextStage();
            }
        }


    }

    private void goToNextStage()
    {
        switch (curStage)
        {
            case Stages.Start:
                {
                    print("TutorialManager: Going from start to kitchen arrow!");
                    // your code 
                    // for plus operator
                    isReading = false;
                    startSlide.SetActive(false);
                    KitchenArrow.SetActive(true);
                    curStage = Stages.WaitForKitchen;
                    break;
                }
            case Stages.WaitForKitchen:
                {
                    print("TutorialManager: Opening kitchen slide!");
                    resetReadTime();
                    isReading = true;
                    
                    KitchenSlide.SetActive(true);
                    curStage = Stages.ReadingKitchen;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.ReadingKitchen:
                {
                    KitchenArrow.SetActive(false);
                    KitchenSlide.SetActive(false);
                    isReading = false;
                    curStage = Stages.MixingWhatever;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.MixingWhatever:
                {
                    DrinkArrow.SetActive(true);
                    curStage = Stages.WaitForDrinks;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.WaitForDrinks:
                {
                    resetReadTime();
                    isReading = true;
                    DrinkSlide.SetActive(true);
                    curStage = Stages.ReadingDrinks;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.ReadingDrinks:
                {
                    DrinkArrow.SetActive(false);
                    isReading = false;
                    DrinkSlide.SetActive(false);
                    curStage = Stages.DrinkingWhatever;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.DrinkingWhatever:
                {
                    resetReadTime();
                    isReading = true;
                    SpaceSlide.SetActive(true);
                    curStage = Stages.LearningSpaceLimitation;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.LearningSpaceLimitation:
                {
                    resetReadTime();
                    SpaceSlide.SetActive(false);
                    firstCustSlide.SetActive(true);
                    curStage = Stages.LearningCustomers;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.LearningCustomers:
                {
                    print("Tutorial Manager: Spawning customer!");
                    isReading = false;
                    firstCustSlide.SetActive(false);
                    //Spawn customer
                    GameObject nextCustomerObject = Instantiate(customerPrefab, customerLocation.position, Quaternion.identity);
                    Customer nextCustomer = nextCustomerObject.GetComponent<Customer>();
                    nextCustomer.lineTimer = 9999.0f; //Make it so player gets infinite time
                    nextCustomer.tableTimer = 9999.0f; //make it so player gets infinite time

                    curStage = Stages.FirstCustomerArrives;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.FirstCustomerArrives:
                {
                    curStage = Stages.CustomerSatDown;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.CustomerSatDown:
                {
                    resetReadTime();
                    isReading = true;
                    //Check whetehr customer was satisfied
                    if (customerSatisfied)
                    {
                        print("TutorialManager: Customer fed correctly!");
                        resetReadTime();
                        isReading = true;
                        Clock.SetActive(true);
                        ClockArrow.SetActive(true);
                        CorrectServeSlide.SetActive(true);
                        curStage = Stages.CustomerSuccessShowClock;
                    }
                    else
                    {
                        resetReadTime();
                        print("TutorialManager: Customer fed wrong!");
                        WrongServeSlide.SetActive(true);
                        curStage = Stages.CustomerFedWrong;
                    }

                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.CustomerFedWrong:
                {
                    WrongServeSlide.SetActive(false);
                    //Customer fed wrong, spawn another customer and go back two stages
                    isReading = false;

                    //Spawn customer
                    GameObject nextCustomerObject = Instantiate(customerPrefab, customerLocation.position, Quaternion.identity);
                    Customer nextCustomer = nextCustomerObject.GetComponent<Customer>();
                    nextCustomer.lineTimer = 9999.0f; //Make it so player gets infinite time
                    nextCustomer.tableTimer = 9999.0f; //make it so player gets infinite time

                    curStage = Stages.FirstCustomerArrives;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.CustomerSuccessShowClock:
                {
                    resetReadTime();
                    ClockArrow.SetActive(false);
                    CorrectServeSlide.SetActive(false);
                    RepBarSlide.SetActive(true);
                    RepBar.SetActive(true);
                    RepArrow.SetActive(true);

                    curStage = Stages.ReadRepbar;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.ReadRepbar:
                {
                    resetReadTime();
                    RepBarSlide.SetActive(false);
                    RepArrow.SetActive(false);
                    finalSlide.SetActive(true);
                    curStage = Stages.ReadFinal;

                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case Stages.ReadFinal:
                {

                    //Go to actual kitchen scene
                    SceneManager.LoadScene("SampleScene");

                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            default: break;
        }
    }
}
