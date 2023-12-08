using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openingAnimaticScript : MonoBehaviour
{

    [SerializeField] Sprite image2;

    [SerializeField] Sprite image3;

    [SerializeField] Sprite image4;

    [SerializeField] Sprite image5;

    [SerializeField] SpriteRenderer animaticDisplay;

    int imageNum;

    // Start is called before the first frame update
    void Start()
    {
        imageNum = 2;
    }

    private void OnMouseUp()
    {
        if (imageNum == 2)
        {
            animaticDisplay.sprite = image2;
        }

        else if (imageNum == 3)
        {
            animaticDisplay.sprite = image3;
        }

        else if (imageNum == 4)
        {
            animaticDisplay.sprite = image4;
        }

        else if (imageNum == 5)
        {
            animaticDisplay.sprite = image5;
        }

        else
        {
            SceneManager.LoadScene("SampleScene");
        }

        imageNum++;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
