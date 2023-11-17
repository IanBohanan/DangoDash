using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[SerializeField]
//enum drinkType
//{
    //replace with actual drink names later
   // A, //0
   // B, //1
   // C, //2
//}
public class DrinkingCup : MonoBehaviour
{
    public static event Action cupFilled;

    private void Start()
    {
        hasButton = false;
    }
    //the button/machine the drink is currently snapped to
    public DrinkButton associatedButton;
    //[SerializeField]public drinkType drink;

    //is set to true if the drink is already snapped to a machine
    public bool hasButton;

    private void OnMouseUp()
    {
        if (hasButton == true)
        {
            
            //if hovering over a button, snap to it
            associatedButton.setDrink(gameObject);
        }
        else
        {
            cupFilled?.Invoke();
            Destroy(gameObject);
        }
    }
    public void generateDrink(int drinkType)
    {
        cupFilled?.Invoke();
        switch (drinkType)
        {
            case 0:
                //outputFood?.Invoke(foodName.BOBATEA);
                print("DrinkingCup: CUM CUP");
                Destroy(gameObject);
                break;
            case 1:
                //outputFood?.Invoke(foodName.TAROTEA);
                print("MERCURY CUP");
                Destroy(gameObject);
                break;
            case 2:
                //outputFood?.Invoke(foodName.BROWNTEA);
                print("POOP CUP");
                Destroy(gameObject);
                break;
            default:
                break;
        }
        
    }

    public void drinkMouseUp()
    {
     

        OnMouseUp();
    }
    /*void snapToButton()
    {
        transform.position = associatedButton.associatedCupPosition;
    }
    */
}
