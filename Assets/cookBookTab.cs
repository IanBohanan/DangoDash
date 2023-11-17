using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookBookTab : MonoBehaviour
{
    [SerializeField] SpriteRenderer cookBook;
    [SerializeField] Sprite recipeSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        cookBook.sprite = recipeSprite;
    }
}
