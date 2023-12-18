using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsClickManager : MonoBehaviour
{
    private bool canClickThru = false;
    private bool changedPages = false;

    [SerializeField] private GameObject credits_page; //The credits page to disable
    [SerializeField] private GameObject links_page; //The links page to enable

    private void OnEnable()
    {
        DelayedAnim.finalFadeOut += enableClickThru;
    }


    //enable the second page of credits
    void enableClickThru()
    {
        canClickThru = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canClickThru && !changedPages) //Only detect clicking once all the credits have been shown (and the anims have been played)
        {
            if(Input.GetMouseButtonDown(0))
            {
                credits_page.SetActive(false);
                links_page.SetActive(true);
                changedPages = true;
            }
        }
    }
}
