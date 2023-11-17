using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    private Customer seatedCustomer; //What customer is seated at this table?

    public enum TableState
    {
        EMPTY, //Table is waiting for customer
        SEATED, //Table has customer waiting for food
        FULL //Table is has customer w/their food and cannot be interacted with for a bit
    }

    public TableState state = TableState.EMPTY;

    void OnEnable()
    {
        StardewClock.dayOver += endOfDay;
    }

    private void OnDisable()
    {
        StardewClock.dayOver -= endOfDay;
    }

    private void endOfDay()
    {
        free();
    }

    public void seatCustomer(Customer r_customer)
    {
        state = TableState.SEATED;
        seatedCustomer = r_customer;
    }

    public void receiveFood(Food food)
    {
        seatedCustomer.eat(food);
        free();
    }

    // Start is called before the first frame update
    public void free()
    {
        state = TableState.EMPTY;
        seatedCustomer = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
