using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    public enum TableState
    {
        EMPTY, //Table is waiting for customer
        SEATED, //Table has customer waiting for food
        FULL //Table is has customer w/their food and cannot be interacted with for a bit
    }

    public TableState state = TableState.EMPTY;

    public void seatCustomer()
    {
        state = TableState.SEATED;
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
