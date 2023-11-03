using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    //The value associated with the ingredient this is attached to; taken by the cookingPot for mixing
    //Chocolate = 19, Mochi = 53, Flour = 37, Strawberry = 89, Sticks = 97, MIlk = 83, 
    public int ingredientValue;

    [SerializeField]public cookingPot mainPot;

    private void OnMouseUp()
    {
        mainPot.checkAddIngredient();
    }

    private void Start()
    {
        //mainPot = gameObject.GetComponentInParent<cookingPot>();
        //mainPot = this.GetComponentInParent<GameObject.CookingPot>();
    }
}
