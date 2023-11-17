using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class exitButtonCookingArea : MonoBehaviour
{
    public static event Action kitchenAreaClosed;
    [SerializeField]
    private GameObject tables;
    [SerializeField]
    private GameObject cookingArea;

    public SpriteRenderer exampleAnim;

    private void OnEnable()
    {
        StardewClock.dayOver += closeKitchen;
        RepBar.gameOver += closeKitchen;
    }

    private void OnDisable()
    {
        StardewClock.dayOver -= closeKitchen;
        RepBar.gameOver -= closeKitchen;
    }

    private void OnMouseDown()
    {
        closeKitchen();
    }

    private void closeKitchen()
    {
        kitchenAreaClosed?.Invoke();
        cookingArea.SetActive(false);
        exampleAnim.sprite = null;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}