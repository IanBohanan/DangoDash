using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkButton : MonoBehaviour
{

    //The machine/collider this is placed with
    [SerializeField] GameObject associatedMachine;
    //the drink contained in the machine with this button
    [SerializeField] GameObject containedDrink;
    //The position a cup in the machine with this button should be placed
    [SerializeField]public Vector3 associatedCupPosition;
    //The type of drink dispensed by this particular machine; may be moved to DrinkingCup, we'll see
    //0 = A, 1 = B, 2 = C
    [SerializeField] int dispensedLiquid;

    public bool hasCup;

    void Start()
    {
        //cupPosition = new Vector3(this.transform.position.x - 100, this.transform.position.y, this.transform.position.z);   
        //cup position should be 
    }

    void Update()
    {
        
    }
    //sets the passed drinkingCup into its spot under the machine and assigns it to containedDrink
    public void setDrink(GameObject cup)
    {
        containedDrink = cup;
        //print("drink set");
        if (cup.GetComponent<DrinkingCup>().hasButton==true)
        {
            print("cup switched buttons");
            cup.GetComponent<DrinkingCup>().associatedButton.hasCup = false;
        }

        cup.GetComponent<DrinkingCup>().associatedButton = this;


        //sets the drink's home point to here;
        containedDrink.GetComponent<ClickDragTest>().setHome(associatedCupPosition);

        //snaps the drink to the base of the machine
        containedDrink.transform.position = associatedCupPosition;

        hasCup = true;
        
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        associatedMachine.GetComponent<DrinkMachine>().machineTrigger(collision);
    }

    public void unsetDrink()
    {
        hasCup = false;
        containedDrink.GetComponent<DrinkingCup>().hasButton = false;
        //print("drink unset");
    }
    //when the button sprite is pressed
    //animates the cup and ships it off to the serving screen
    private void OnMouseDown()
    {
        print("button pressed");
        if (hasCup)
        {
            containedDrink.GetComponent<DrinkingCup>().generateDrink(dispensedLiquid);
        }
        //set animation stuff for the cup here




    }


}
