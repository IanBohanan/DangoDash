using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class SlideManager : MonoBehaviour
{
    public static event Action slideAdvance;

    public int slideNum = 1;
    public List<GameObject> slides;

    void nextSlide()
    {
        
        slideNum++;
        if(slideNum >= 14)
        {
            SceneManager.LoadScene("TitleTentative");
        }
        else
        {
            slides[slideNum - 1].SetActive(false);
            slides[slideNum].SetActive(true);
            slideAdvance?.Invoke();
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nextSlide();
        }
    }

}
