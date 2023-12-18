using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLink : MonoBehaviour
{
    public void sendToPhilTumblr()
    {
        Application.OpenURL("https://ahoygamers.tumblr.com/");
    }

    public void sendToEmInstagram()
    {
        Application.OpenURL("https://www.instagram.com/erld.exe/");
    }

    public void sendToMainMenu()
    {
        SceneManager.LoadScene("TitleTentative");
    }
}
