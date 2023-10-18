using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggler : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button;
    
    public void TogglePanel() {
        if(Panel != null) {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }

        if(Button != null) {
            bool isActive = Button.activeSelf;
            Button.SetActive(!isActive);
        }
    }
}
