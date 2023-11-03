using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
enum drinkType
{
    //replace with actual drink names later
    A, //0
    B, //1
    C, //2
}
public class DrinkingCup : MonoBehaviour
{
    public int drinkType;
    //[SerializeField]public drinkType drink;

    //is set to true if the drink is already snapped to a machine
    public bool hasButton;

    [SerializeField] public DrinkButton associatedButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the collided object is a cup
        if (collision.gameObject.GetComponent<ClickDragTest>())
        {
            //tie it to the appropriate button
            associatedButton.setDrink(collision.gameObject);

            hasButton = true;
        }


    }

    public void generateDrink(int drinkType)
    {
        switch (drinkType)
        {
            case 0:
                //outputFood?.Invoke(foodName.BOBA);
                break;
        }

    }

}
