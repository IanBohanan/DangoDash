using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupStack : MonoBehaviour
{


    Vector3 mousePositionOffset;
    public GameObject thesillycup;
    private bool cupExists = false;
    // Start is called before the first frame update

    public GameObject cupPrefab;
    private void OnEnable()
    {
        DrinkingCup.cupFilled += onCupFilled;
    }

    private void OnDisable()
    {
        DrinkingCup.cupFilled -= onCupFilled;
    }


    private void OnMouseDown()
    {
        if (!cupExists)
        {
            mousePositionOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            GameObject newCup = Instantiate(cupPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 8), Quaternion.identity);

            newCup.GetComponent<ClickDragTest>().startDrag();

            thesillycup = newCup;

            cupExists = true;
        }

    }

    private void OnMouseUp()
    {
        if(cupExists)
        {
            thesillycup.GetComponent<DrinkingCup>().drinkMouseUp();
            thesillycup.GetComponent<ClickDragTest>().altMouseUp();
        }
    }

    private void onCupFilled()
    {
        print("cupStack: cup has been released!");
        cupExists = false;
    }

}
