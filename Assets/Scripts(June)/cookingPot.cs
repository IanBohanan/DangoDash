using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class cookingPot : MonoBehaviour
{

    //General Idea: pull from the pot's holdingBay, add that to an overall value, from there determine the food that's exported

    //tracks the number of ingredients currently in the pot; when this hits 3, a food is made

    //make all ingredientValues prime numbers for ease of addition

    int ingredientCount = 0;

    int ingredientValue = 0;

    [SerializeField] holdingBay connectedBay;

    //used to reset ingredients' positions after use
    ClickDragTest ingredientMove;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (connectedBay.containedItem != null)
        {
            //If the bay is not empty, pull the ingredient stored within into the pot
            addIngredient(connectedBay.containedItem);
        }


    }

    public void addIngredient(GameObject ingredient)
    {

        //math stuff
        Debug.Log("got item");

        //checks for what ingredient was passed in
        //for now, this is done by object name, there's probably a better way to do this but it's functional for now
        if (ingredient.name == "Chocolate")
        {
            print("got chocolate");
            ingredientValue += 19;
        }

        else if (ingredient.name == "Mochi")
        {
            ingredientValue += 53;
        }

        else if (ingredient.name == "Flour")
        {
            ingredientValue += 37;
        }

        else if (ingredient.name == "Strawberry")
        {
            ingredientValue += 89;
        }

        else if (ingredient.name == "Sticks")
        {
            ingredientValue += 97;
        }

        else if (ingredient.name == "Milk")
        {
            ingredientValue += 83;
        }

        //if the passed object is not any of the expected ingredients, neutralizes the effects on any important values and moves on
        else
        {
            Debug.Log("unrecognized ingredient");
            ingredientCount -= 1;
        }


        ingredientCount += 1;




        //moves the ingredient back to its spot on the shelf
        ingredientMove = ingredient.GetComponent<ClickDragTest>();

        ingredientMove.resetPosition();

        //removes the ingredient from the bay
        connectedBay.clearBay();

        if (ingredientCount == 3)
        {
            mixIngredients();
        }

    }


    //I still need the cookbook/recipes to add everything to this
    public void mixIngredients()
    {

        //might change this to switch statements whenever time allows, for sake of clarity


        //checks for overall ingredientValue and produces a food accordingly


        //example: flour + chocolate + milk = takoyaki
        if (ingredientValue == 139)
        {
            outputFood?.Invoke(foodName.CATBAG);
        }

        //mochi + flour + strawberry = Strawberry Mochi
        else if (ingredientValue == 179)
        {
            outputFood?.Invoke(foodName.BOBA);
        }


        //if set of ingredients isn't in list
        else
        {
            //produce junkFood
        }

        ingredientCount = 0;

        ingredientValue = 0;









    }



    //prototype for unity actions

    public static event Action<foodName> outputFood;



}

