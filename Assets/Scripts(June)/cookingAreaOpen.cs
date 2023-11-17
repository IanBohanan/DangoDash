using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class cookingAreaOpen : MonoBehaviour
{

    //stores the cookingArea to open/close
    public Animator foodAnim;

    public SpriteRenderer renderer;

    public Sprite bobaSprite;
    public Sprite taiyakiSprite;
    public Sprite trashSprite;

    //When object created (and enabled) subscribe to the customer's leaving
    private void OnEnable()
    {
        cookingPot.outputFood += setFoodAnim;
    }

    //When object created (and enabled) unsubscribe to the customer when they left
    //Very important or else errors will happen!
    private void OnDisable()
    {
        cookingPot.outputFood -= setFoodAnim;
    }

    public void setFoodAnim(foodName food)
    {
        renderer.enabled = true;
        //Reset the food animator to the entry state
        
        switch(food)
        {
            case foodName.BOBA:
                renderer.sprite = bobaSprite;
                break;
            case foodName.TAIYAKI:
                renderer.sprite = taiyakiSprite;
                break;
            default:
                renderer.sprite = trashSprite;
                break;
        }

        foodAnim.Play("FlyOut");
    }

}
