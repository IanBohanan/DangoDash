using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown == true)
        {
            //Whenever the player hits a button, moves to the next scene
            SceneManager.LoadScene("TitleTentative");
        }
    }

    
}
