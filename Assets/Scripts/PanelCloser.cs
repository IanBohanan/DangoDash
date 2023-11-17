using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PanelCloser : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button;
    
    public void ClosePanel() {
        if(Panel != null) {
            Panel.SetActive(false);
        }

        if(Button != null) {
            Button.SetActive(false);
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene("TitleTentative");
    }

}
