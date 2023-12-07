using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsScript : MonoBehaviour
{
    // Start is called before the first frame update


    public void goToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
