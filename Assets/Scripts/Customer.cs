using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class Customer : MonoBehaviour
{

    public foodName desiredFood; //What food does this customer want?

    public float lineTimer = 10.0f; //Time until customer leaves after entering store

    public float tableTimer = 20.0f; //Time until customer leaves after being seated

    public float timeLeft; //Time in seconds until something happens

    public static event Action<bool> customerLeft; //Action that shows customer left. Bool - was the customer happy when they left?

    public bool isHappy = false;

    private GameObject curTable = null; //Which table is this customer currently sitting at?

    private Vector3 lastValidCoords; //The last valid position of the Customer. If they are dragged to an invalid location, they will return here.

    private ClickDragTest dragScript;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            GameObject hitObject = collision.gameObject;
            if (hitObject.GetComponent<Table>())
            {
                print("I touched a table!");
                curTable = hitObject;
            }
            
        }
        catch (Exception a) { }
    }

    //Generates a random food value from the foodName enum
    //TODO: This might miss the last value in the enum array? Be sure to check
    private void generateFood()
    {
        desiredFood = (foodName)UnityEngine.Random.Range(0, Enum.GetValues(typeof(foodName)).Cast<int>().Max());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        try
        {
            curTable = null;
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
        if(dragScript.isBeingDragged())
        {
            try //If the customer was over a table, then sit the customer there
            {
                Table draggedTable = curTable.GetComponent<Table>();
                //Is the table they're trying to sit at already taken?
                if (draggedTable.state == Table.TableState.EMPTY)
                {
                    //Table is empty! Have the customer sit in the chair, then update state, reset timer, and disable ability to drag
                    this.transform.position = curTable.transform.Find("LeftChair").transform.position;
                    print("Customer: I sat at the table!");
                    state = CustomerState.SEATED;
                    draggedTable.seatCustomer();
                    timeLeft = tableTimer;
                    Destroy(GetComponent<ClickDragTest>());
                }
                else
                {
                    print("Customer: I tried to sit, but table was full!");
                    //Table is full, return customer to its spawn point
                    tweenToLocation(lastValidCoords);
                }

                curTable = null;
            }
            catch (Exception a) //If the customer was over a non-table
            {
                print("Customer:Dragged over non-table object!");
                tweenToLocation(lastValidCoords);
                //Go back to spawn point
            }
        }
    }

    //Updates the timer every frame.
    //Once the timer reaches zero, the customer leaves and notifies the game that they left
    private void updateTimer()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            customerLeft?.Invoke(isHappy);
            Destroy(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(state != CustomerState.FED)
        {
            updateTimer();
        }
        
    }
}
