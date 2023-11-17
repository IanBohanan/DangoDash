using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextAdvance : MonoBehaviour
{
    [SerializeField]
    public List<string> lines;
    private int lineNum = 0;

    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        SlideManager.slideAdvance += nextLine;
    }

    private void OnDisable()
    {
        SlideManager.slideAdvance -= nextLine;
    }

    private void nextLine()
    {
        print("Next line arrived!");
        lineNum++;
        textMeshPro.text = lines[lineNum];
    }
}
