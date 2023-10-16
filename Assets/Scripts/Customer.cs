using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Customer : MonoBehaviour
{
    public float timeLeft = 5.0f; //Time in seconds until something happens

    public static event Action<bool> customerLeft; //Action that shows customer left. Bool - was the customer happy when they left?

    public bool isHappy = false;

    public bool isSitting = false; //Is the customer currently at a table?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Table table = collision.gameObject.GetComponent<Table>();

            isSitting = true;
        }
        catch (Exception a) { }
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
        updateTimer();
    }
}
