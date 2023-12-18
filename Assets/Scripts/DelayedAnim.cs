using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DelayedAnim : MonoBehaviour
{
    public static event Action finalFadeOut; //Lets the clickManager know this is the final delayed Anim
    [SerializeField] private bool isFinalFlyOut = false; //When animation played, should this send out the final event
    public float timeLeft; //Time in seconds until animator plays
    private bool playedAnim = false;
    [SerializeField] private Animator anim; //The animator that plays the animation

    //Updates the timer every frame.
    //Once the timer reaches zero, the customer leaves and notifies the game that they left
    private void updateTimer()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            //Play anim
            anim.Play("MoveRight");
            playedAnim = true;

            if(isFinalFlyOut)
            {
                finalFadeOut?.Invoke();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playedAnim)
        {
            updateTimer();
        }
    }
}
