using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleButtonStates : MonoBehaviour
{
    public Sprite unmutedSprite;
    public Sprite mutedSprite;

    private Image buttonImage;
    private bool isMuted = false;

    private void Start()
    {
        buttonImage = GetComponent<Image>();

        // Set the initial sprite
        buttonImage.sprite = isMuted ? mutedSprite : unmutedSprite;
    }

    public void OnButtonClick()
    {
        // Toggle the mute state
        isMuted = !isMuted;

        // Switch the sprite based on the mute state
        buttonImage.sprite = isMuted ? mutedSprite : unmutedSprite;
    }
}