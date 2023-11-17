using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class overworldJuiceM : MonoBehaviour
{
    public static event Action drinkAreaOpened;

    private BoxCollider2D mouseCollider;

    [SerializeField]
    private GameObject drinkArea;

    // Start is called before the first frame update
    void Start()
    {
        mouseCollider = this.transform.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        KitchenDoor.kitchenAreaOpened += onMenuOpen;
        exitButtonCookingArea.kitchenAreaClosed += onMenuClose;
    }

    private void OnDisable()
    {
        KitchenDoor.kitchenAreaOpened -= onMenuOpen;
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


    private void OnMouseDown()
    {
        drinkAreaOpened?.Invoke();
        drinkArea.SetActive(true);
        mouseCollider.enabled = false;
    }
}
