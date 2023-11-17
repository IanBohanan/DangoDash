using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public enum foodName
{
    TAIYAKI,
    STRAWMOCHI,
    DANGO,
    TRASH
}

public class Food : MonoBehaviour
{
    public static event Action<int> leftCounter;

    [SerializeField]
    public foodName name;
    public Animator foodDisplay; //The animator that displays the food
    public int spotInLine = -1; //Where is its spot on the counter

    private BoxCollider2D mouseCollider;

    void Start()
    {
        mouseCollider = this.transform.gameObject.GetComponent<BoxCollider2D>();
    }

    void OnEnable()
    {
        StardewClock.dayOver += endOfDay;
        overworldJuiceM.drinkAreaOpened += menuOpened;
        exitButtonCookingArea.kitchenAreaClosed += onMenuClose;
        KitchenDoor.kitchenAreaOpened += menuOpened;
        
    }

    private void OnDisable()
    {
        StardewClock.dayOver -= endOfDay;
        overworldJuiceM.drinkAreaOpened -= menuOpened;
        exitButtonCookingArea.kitchenAreaClosed -= onMenuClose;
        KitchenDoor.kitchenAreaOpened -= menuOpened;
    }

    private void endOfDay()
    {
        Destroy(this.transform.gameObject);
    }

    private void menuOpened()
    {
        mouseCollider.enabled = false;
    }

    private void onMenuClose()
    {
        mouseCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Table hitTable = collision.gameObject.GetComponent<Table>();
            
            if(hitTable.state == Table.TableState.SEATED)
            {
                leftCounter?.Invoke(spotInLine);
                hitTable.receiveFood(this);
                Destroy(transform.gameObject);
            }
        }
        catch (Exception a) { }
    }

    //Generates a random food for the desired food
    //Todo: test if this misses the last food icon? Might be one off?
    public void generateName()
    {
        name = (foodName)UnityEngine.Random.Range(0, Enum.GetValues(typeof(foodName)).Cast<int>().Max());
        updateAnim();
    }

    public void setName(foodName r_name)
    {
        name = r_name;
        updateAnim();
    }

    public void updateAnim()
    {
        try
        {
            foodDisplay.SetInteger("FoodNum", (int)name); //Display the correct food
        }
        catch (Exception e) { }
        
    }
}
