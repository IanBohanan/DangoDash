using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookBookExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField] GameObject cookBook;
    private void OnMouseDown()
    {
        cookBook.SetActive(false);
    }
}
