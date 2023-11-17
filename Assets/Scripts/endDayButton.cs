using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endDayButton : MonoBehaviour
{
    private GameObject endDayCanvas;

    public void startNewDay()
    {
        endDayCanvas.SetActive(false);
    }
}
