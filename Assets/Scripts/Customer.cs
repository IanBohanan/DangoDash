using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Customer : MonoBehaviour
{

    public static event Action<int> leftLine; //Event signal when customer leaves the line. Sent out: int which spot in line they were

    public int spotInLine; //Which spot in line did this customer take when it spawned?

    private Food desiredFood = new Food(); //What food does this customer want?

    public foodName debugfoodname;

    public float lineTimer = 10.0f; //Time until customer leaves after entering store

    public float tableTimer = 20.0f; //Time until customer leaves after being seated

    public float timeLeft; //Time in seconds until something happens

    public static event Action<bool> customerLeft; //Action that shows customer left. Bool - was the customer happy when they left?

    public bool isHappy = false;

    public GameObject curTable = null; //Which table is this customer currently sitting at?

    private Vector3 lastValidCoords; //The last valid position of the Customer. If they are dragged to an invalid location, they will return here.

    private ClickDragTest dragScript;

    [SerializeField]
    private GameObject thinkCloud; //The cloud gameObject that shows what the customer wants
    [SerializeField]
    private GameObject tableIcon; //The table icon that shows a table when the customer is standing in line
    [SerializeField]
    private GameObject foodIcon; //The food icon that shows which food the customer wants (after they have already sat down)
    [SerializeField]
    private Renderer cloudRenderer; //The cloud sprite object's renderer. Used to change its color
    [SerializeField]
    private Animator foodDisplay; //The animator that displays the desired food object

    public enum CustomerState
    {
        WAITING, //Customer waiting for a table
        SEATED, //Customer seated waiting for food
        FED //Customer is fed
    }

    public CustomerState state = CustomerState.WAITING;

    // Start is called before the first frame update
    void Start()
    {

        generateFood();
        timeLeft = lineTimer;
        lastValidCoords = transform.position;
        dragScript = GetComponent<ClickDragTest>();
        dragScript.autoReturn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            GameObject hitObject = collision.gameObject;
            if (hitObject.GetComponent<Table>() && state == CustomerState.WAITING)
            {
                curTable = hitObject;
            }

        }
        catch (Exception a) { }
    }

    //Generates a random food for the desired food, then set the foodCloud's desiredFood icon to the generated food
    private void generateFood()
    {
        desiredFood.generateName();
        debugfoodname = desiredFood.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        try
        {
            if (collision.transform.gameObject.GetComponent<Table>())
            {
                curTable = null;
            }

        }
        catch (Exception a) { }
    }

    //Smoothly tween the customer to a location
    private void tweenToLocation(Vector3 coords)
    {
        transform.position = coords;
    }

    private void OnMouseUp()
    {
        if (dragScript.isBeingDragged())
        {
            try //If the customer was over a table, then sit the customer there
            {
                Table draggedTable = curTable.GetComponent<Table>();
                //Is the table they're trying to sit at already taken?
                if (draggedTable.state == Table.TableState.EMPTY)
                {
                    //Update the icon to display their desired food 
                    tableIcon.SetActive(false);
                    foodIcon.SetActive(true);

                    //Table is empty! Have the customer sit in at the table.
                    sitAtTable(draggedTable);

                }
                else
                {
                    print("Customer: I tried to sit, but table was full!");
                    //Table is full, return customer to its spawn point
                    tweenToLocation(lastValidCoords);
                    curTable = null;
                }


            }
            catch (Exception a) //If the customer was over a non-table
            {
                tweenToLocation(lastValidCoords);
                //Go back to spawn point
            }
        }
    }

    //Has the customer sit at a table. Updates its state (and the table's state) 
    //and displays what food they want
    private void sitAtTable(Table table)
    {
        state = CustomerState.SEATED;
        leftLine?.Invoke(spotInLine); //Tell the CustomerSpawner its sat down and it should free the spot in line
        this.transform.position = curTable.transform.Find("LeftChair").transform.position;     
        table.seatCustomer(this);
        timeLeft = tableTimer;
        Destroy(GetComponent<ClickDragTest>()); //Customer should not be dragged anymore after this. So destroy ability yo drag
        thinkCloud.SetActive(true);
        foodDisplay.SetInteger("FoodNum", (int)desiredFood.name); //Display the correct food above their head
    }

    //Eats a given food object and determines whether it was correct or not
    public void eat(Food food)
    {

        if (food.name.Equals(desiredFood.name))
        {
            isHappy = true;
        }
        else
        {
            isHappy = false;
        }
        leaveRestraunt();
    }

    //Updates the timer every frame.
    //Once the timer reaches zero, the customer leaves and notifies the game that they left
    private void updateTimer()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            isHappy = false;
            leftLine?.Invoke(spotInLine); //Tell the CustomerSpawner its sat down and it should free the spot in line
            leaveRestraunt();
        }
    }

    private void leaveRestraunt()
    {

        if(isHappy)
        {
            print("Customer was fed and satisfied!");
        }
        else
        {
            print("Customer ran out of time!");
        }

        try
        {
            curTable.GetComponent<Table>().free();
            print("Customer was at table!");
        }
        catch (Exception e) { }
        customerLeft?.Invoke(isHappy); //Tell reputation bar the customer left
        Destroy(transform.gameObject);

    }

    //Updates the color of the customer's cloud based on the timer.
    //Smoothly interpolates the cloud from green (max timer) to red (timer hits zero)
    private void updateCloudColor()
    {
        float normalizedTime; //How much time has been taken up by the customer, expressed as a percent between 0 and 1. (ex. 50% of the timer is depleted, this value will be 0.5)

        //Need to determine WHICH timer is running and how much has been "consumed". 
        //Clamp01 will turn it into a num from 0 and 1, like real percentages!
        if(state == CustomerState.WAITING)
        {
            normalizedTime = Mathf.Clamp01(timeLeft/lineTimer); 
        }
        else //There are no other max timers, so just using a generic else.
        {
            normalizedTime = Mathf.Clamp01(timeLeft/tableTimer);
        }

        //Determines the color between 0 and 1, 0 is green while 1 is red. So subtract the amount of time consumed from the red "1" maximum.
        Color lerpedColor = Color.Lerp(Color.green, Color.red, 1.0f - normalizedTime);

        //Now set the color of the thought bubble
        cloudRenderer.material.color = lerpedColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != CustomerState.FED)
        {
            updateTimer();
        }

        //then update the color of the thinkCloud
        updateCloudColor();
    }
}