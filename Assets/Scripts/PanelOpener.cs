using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button;
    
    public void OpenPanel() {
        if(Panel != null) {
            Panel.SetActive(true);
        }

        if(Button != null) {
            Button.SetActive(true);
        }
    }
}
