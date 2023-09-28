//This script will change the theme of a restraunt piece

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTheme : MonoBehaviour
{
    public Theme[] themes;

    public SpriteRenderer upperWall;
    public SpriteRenderer lowerWall;
    public SpriteRenderer upperFloor;
    public SpriteRenderer lowerFloor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            upperWall.sprite = themes[0].upperWallPaper;
            lowerWall.sprite = themes[0].lowerWallPaper;
        }
    }
}
