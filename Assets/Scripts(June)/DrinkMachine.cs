using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMachine : MonoBehaviour
{

    public int drinkType;
    public DrinkButton associatedButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //If the collided object is a cup
        if (collision.gameObject.GetComponent<DrinkingCup>())
        {
            //tie it to the appropriate button
            associatedButton.setDrink(collision.gameObject);

            collision.gameObject.GetComponent<DrinkingCup>().hasButton = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("trigger exit");
        //If the collided object is a cup
        if (collision.gameObject.GetComponent<DrinkingCup>())
        {
            //tie it to the appropriate button
            associatedButton.unsetDrink();

            //collision.gameObject.GetComponent<DrinkingCup>().hasButton = false;
        }


    }

    public void machineTrigger(Collider2D collision)
    {
        
        OnTriggerEnter2D(collision);
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
