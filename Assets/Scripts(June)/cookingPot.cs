using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class cookingPot : MonoBehaviour
{


    //prototype for unity actions

    public static event Action<foodName> outputFood;
    //General Idea: pull from the pot's holdingBay, add that to an overall value, from there determine the food that's exported

    //tracks the number of ingredients currently in the pot; when this hits 3, a food is made

    //make all ingredientValues prime numbers for ease of addition
    [SerializeField] cookingMeter cookingBar;

    public int ingredientCount = 0;

    public int ingredientValue = 0;

    [SerializeField]Ingredient passedIngredient;
    

    [SerializeField] holdingBay connectedBay;

    GameObject ingredientToAdd;

    //used to reset ingredients' positions after use
    ClickDragTest ingredientMove;

    bool addTrigger;
    private void Start()
    {
        addTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        print("trigger entered");
        if (collision.gameObject.GetComponent<Ingredient>())
        {
            ingredientToAdd = collision.gameObject;
            addTrigger = true;
        }
    }
    //addIngredient(collision.gameObject);

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("trigger exited");
        if (collision.gameObject.GetComponent<Ingredient>())
        {
            addTrigger = false;
        }
    }

    public void checkAddIngredient()
    {
        if (addTrigger == true)
        {
            print("added ingredient");
            addIngredient(ingredientToAdd);
        }
    }

    public void addIngredient(GameObject ingredient)
    {


        //adds the passed ingredientValue


        ingredientValue += ingredient.GetComponent<Ingredient>().ingredientValue;




        ingredientCount += 1;

        cookingBar.setSprite(ingredientCount);

        //moves the ingredient back to its spot on the shelf
        try
        {
            ingredientMove = ingredient.GetComponent<ClickDragTest>();
            ingredientMove.resetPosition();
        }
        catch (Exception e) { };


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
        //new switch statement for this
        //checks for overall ingredientValue and produces a food accordingly
        switch (ingredientValue)
        {
            //example: flour + chocolate + milk = taiyaki
            case 139:
                outputFood?.Invoke(foodName.TAIYAKI);
                break;
            //temporary: Love + balls + milk = Boba
            //case 237:
                //outputFood?.Invoke(foodName.BOBA);
              //break;

            case 179:
                outputFood?.Invoke(foodName.STRAWMOCHI);
            break;

            case 187:
                outputFood?.Invoke(foodName.DANGO);
            break;

            default:
                outputFood?.Invoke(foodName.TRASH);
                break;
        }

        ingredientCount = 0;

        ingredientValue = 0;


    }




}

