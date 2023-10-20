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

    public void seatCustomer(Customer r_customer)
    {
        state = TableState.SEATED;
        seatedCustomer = r_customer;
    }

    public void receiveFood(Food food)
    {
        seatedCustomer.eat(food);
    }

    // Start is called before the first frame update
    public void free()
    {
        print("Table: I am free!");
        state = TableState.EMPTY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
