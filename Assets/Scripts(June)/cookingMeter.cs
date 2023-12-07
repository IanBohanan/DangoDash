using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookingMeter : MonoBehaviour
{
    [SerializeField] SpriteRenderer barSprite;

    [SerializeField]Sprite bar0;

    [SerializeField]Sprite bar1;

    [SerializeField]Sprite bar2;


    public void setSillySprite(int spritenum)
    {
        if(spritenum == 1)
        {
            barSprite.sprite = bar1;
        }

        else if (spritenum == 2)
        {
            barSprite.sprite = bar2;
        }

        else
        {
            barSprite.sprite = bar0;

        }
    }

}
