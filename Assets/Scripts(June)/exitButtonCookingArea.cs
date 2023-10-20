using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitButtonCookingArea : MonoBehaviour
{

    [SerializeField]
    private Animator kitchenArea;

    [SerializeField]
    private GameObject tables;

    private void OnMouseDown()
    {
        kitchenArea.Play("MoveDown");
        tables.SetActive(true);
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
