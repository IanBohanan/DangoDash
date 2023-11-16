using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StardewClock : MonoBehaviour
{
    public Image nightBackground;
    public RectTransform hand;

    public float startTime = 10.0f; //Time until day ends (in seconds).

    public float timeLeft; //Time left for the day

    private bool isTicking = true; //Is the clock counting down?

    // Start is called before the first frame update
    void Start()
    {
        resetClock();
        //nightBackground.fillAmount = tm.nightDuration / 2; Maybe use this in update to make the bar filled?
    }

    void resetClock()
    {
        timeLeft = startTime;
    }

    //Updates the timer every frame.
    //Once the timer reaches zero, the customer leaves and notifies the game that they left
    private void updateTimer()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            //declare day done!
            isTicking = false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTicking)
        {
            updateTimer();

            //Make the hand move based on how much time has passed. 
            /*  90 = day start
             *  0 = midpoint
             *  -90 = day end!
             *  Must travel a total of 180 degrees. Should be proportional to the internal timer. 0% done = 90, 100% done = 270
             *  Interpolation formula, solved for percent done = (timeLeft - startTime) / (endTime - startTime)
             *  So just add the total distance traveled to the start point, proportional to how much timer has already passed.
             *  Basically startrotation - (totalDistance * percentDone)
             * */
            float percentDone = (timeLeft - startTime) / (0 - startTime);

            hand.localRotation = Quaternion.Euler(0, 0, 90 - (180 * percentDone));
        }

    }
}
