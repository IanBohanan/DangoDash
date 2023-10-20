using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject kitchenArea;

    [SerializeField]
    private GameObject tables;
    //When clicked, transition
    private void OnMouseDown()
    {
        kitchenArea.SetActive(true);
        tables.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}