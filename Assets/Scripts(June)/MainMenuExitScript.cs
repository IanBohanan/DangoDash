using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(closeGame);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] Button exitButton;

    void closeGame()
    {

        //closes game
        Application.Quit();
    }
}
