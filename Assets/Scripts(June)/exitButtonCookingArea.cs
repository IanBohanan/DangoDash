using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class exitButtonCookingArea : MonoBehaviour
{
    public Animator foodAnim; //The flying out food anim
    public static event Action kitchenAreaClosed;
    [SerializeField]
    private GameObject tables;
    [SerializeField]
    private GameObject cookingArea;

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
        foodAnim.Play("Hidden");
        kitchenAreaClosed?.Invoke();
        cookingArea.SetActive(false);
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