using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator kitchenArea;

    [SerializeField]
    private GameObject tables;
    //When clicked, transition
    private void OnMouseDown()
    {
        kitchenArea.Play("MoveUp");
        tables.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
