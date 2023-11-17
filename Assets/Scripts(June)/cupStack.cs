using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupStack : MonoBehaviour
{


    Vector3 mousePositionOffset;
    public GameObject thesillycup;

    // Start is called before the first frame update

    public GameObject cupPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject newCup = Instantiate(cupPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition)+ new Vector3(0,0,8), Quaternion.identity);



      
       

        newCup.GetComponent<ClickDragTest>().startDrag();


        thesillycup = newCup;
    }

    private void OnMouseUp()
    {
        thesillycup.GetComponent<DrinkingCup>().drinkMouseUp();
        thesillycup.GetComponent<ClickDragTest>().altMouseUp();

    }

}
