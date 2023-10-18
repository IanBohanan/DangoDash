using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookbookOpen : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when clicked on, deactivates itself, closing the cookbook and returning to the cookingArea
    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }


}
