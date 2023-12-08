using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class KitchenDoor : MonoBehaviour
{

    [SerializeField] GameObject tooMuchFood;

    [SerializeField] FoodSpawnr foodSpawner;

    public static event Action kitchenAreaOpened;

    private BoxCollider2D mouseCollider;

    [SerializeField] AudioSource kitchenOpen;

    [SerializeField]
    private GameObject kitchenArea;

    private void Start()
    {
        mouseCollider = this.transform.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        overworldJuiceM.drinkAreaOpened += onMenuOpen;
        exitButtonCookingArea.kitchenAreaClosed += onMenuClose;
    }

    private void OnDisable()
    {
        overworldJuiceM.drinkAreaOpened -= onMenuOpen;
        exitButtonCookingArea.kitchenAreaClosed -= onMenuClose;
    }


    private void onMenuOpen()
    {
        mouseCollider.enabled = false;
    }

    private void onMenuClose()
    {
        mouseCollider.enabled = true;
    }

    //When clicked, transition
    private void OnMouseDown()
    {
        kitchenOpen.Play();

        kitchenAreaOpened?.Invoke();
        kitchenArea.SetActive(true);

        if (foodSpawner.filledSpotCounter >= 3)
        {
            //display the funny message
            tooMuchFood.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}