using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitButtonCookingArea : MonoBehaviour
{
    //Stores the cooking area
    [SerializeField] GameObject cookingArea;


    private void OnMouseUp()
    {
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
