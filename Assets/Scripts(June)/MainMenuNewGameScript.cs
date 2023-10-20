using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuNewGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        newGame.onClick.AddListener(schmooveScenes);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] Button newGame;

    void schmooveScenes()
    {
        //open the main game scene
        SceneManager.LoadScene("TuutorialTentative");
    }    
}
