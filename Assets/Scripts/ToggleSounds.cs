using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSounds : MonoBehaviour
{
    [SerializeField] private bool _toggleMusic, _toggleEffects;

    public void Toggle() {
        if(_toggleMusic) SoundManager.Instance.ToggleMusic();
        if(_toggleEffects) SoundManager.Instance.ToggleEffects();
    }
}
