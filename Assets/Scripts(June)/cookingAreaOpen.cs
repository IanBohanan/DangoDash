using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cookingAreaOpen : MonoBehaviour
{
    //stores the cookingArea to open/close
    public GameObject cookArea;

    //stores the button to exit the cookingArea
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(closeArea);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //For now, just enables/disables the object; this will hopefully be updated later to include
    private void OnMouseUp()
    {

        cookArea.SetActive(true);
    }

    public void closeArea()
    {
        cookArea.SetActive(false);
    }

}
