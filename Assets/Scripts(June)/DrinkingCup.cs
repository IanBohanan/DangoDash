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
    public static event Action<foodName> outputDrink;


    //the button/machine the drink is currently snapped to
    public DrinkButton associatedButton;
    //[SerializeField]public drinkType drink;

    //is set to true if the drink is already snapped to a machine
    public bool hasButton;

    public SpriteRenderer cupBtm; //The top of the cup that displays empty or the color of the drink

    public GameObject droplet; //The droplet object that will be enabled
    public Animator dropletAnimator; //The animator that controls the droplet's look.

    public Animator cupAnimtor; //animator for the cup. It just makes the cup fly out

    public Sprite bobaTopImage;
    public Sprite taroTopImage;
    public Sprite brownTopTeaImage;

    private void Start()
    {
        hasButton = false;
    }

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

    //Triggered when the cup has started to be filled (player click on the nozzle of drink machine)
    public void generateDrink(int drinkType)
    {
        cupFilled?.Invoke();
        droplet.SetActive(true);
        switch (drinkType)
        {
            case 0: //Boba
                outputDrink?.Invoke(foodName.BOBATEA);
                cupBtm.sprite = bobaTopImage;
                dropletAnimator.Play("DropletBoba");
                break;
            case 1: //Taro
                outputDrink?.Invoke(foodName.TAROTEA);
                cupBtm.sprite = taroTopImage;
                dropletAnimator.Play("TaroDroplet");
                break;
            case 2: //Brown
                outputDrink?.Invoke(foodName.BROWNTEA);
                cupBtm.sprite = brownTopTeaImage;
                dropletAnimator.Play("DropletBrown");
                break;
            default:
                break;
        }
        //todo play sound

        //Let play admire drink for a second before pushing it away
        Invoke("pushAwayDrink", 1); 

    }

    //Pushes the drink away then deletes it
    public void pushAwayDrink()
    {
        droplet.SetActive(false);
        print("Drinking cup: flying away!");
        cupAnimtor.enabled = true;
        cupAnimtor.Play("FlyOut");
        Invoke("deleteSelf", 1); //let the drink fly off, then delete self
    }

    public void deleteSelf()
    {
        print("DrinkingCup: Cup deleted!");
        Destroy(gameObject);

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
