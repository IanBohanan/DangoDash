using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabScript : MonoBehaviour
{
    public GameObject[] tabs;

    public void TurnOnTabs (int tab) // Int is used to enter the button number which are 1, 2, 3 in the inspector
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive(false);
        }
        tabs[tab - 1].SetActive(true);
    }
}
