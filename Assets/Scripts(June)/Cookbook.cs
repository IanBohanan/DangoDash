using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookbook : MonoBehaviour
{
    //The open cookbook
    [SerializeField] GameObject openCookbook;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    //when clicked, activate the cookbook
    private void OnMouseDown()
    {
        openCookbook.SetActive(true);
    }


}
