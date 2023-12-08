using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class creditsReturnScript : MonoBehaviour
{

    [SerializeField] VideoPlayer creditsPlayer;

    [SerializeField] bool waitingForContinueClick = false;

    [SerializeField] bool waitingForExitClick = false;

    // Start is called before the first frame update
    void Start()
    {

        //creditsPlayer = this.gameObject.GetComponent<VideoPlayer>();

        waitingForContinueClick = false;

        waitingForExitClick = false;

        playCreditsOne();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            doThing();
        }
    }

    public void playCreditsOne()
    {



        creditsPlayer.Play();

        //WaitForSeconds();

        //yield return new WaitForSeconds(9);
        //System.Threading.Tasks.sleep();

        //Time until credits are fully displayed
        //Thread.Sleep(9000);
        Invoke("playCreditsTwo", 9);
     }

    public void playCreditsTwo() { 
        //Wait(2);

        creditsPlayer.Pause();

        waitingForContinueClick = true;

        
    }
  

    public void playCreditsThree()
    {
        waitingForExitClick = true;

        creditsPlayer.Pause();
    }
    public void doThing()
    {

        if (waitingForContinueClick)
        {
            creditsPlayer.Play();

            waitingForContinueClick = false;

            //Remaining animation time
            //Thread.Sleep(10000);

            Invoke("playCreditsThree", 10);

            

            
        }

        else if (waitingForExitClick)
        {
            SceneManager.LoadScene("TitleTentative");
        }

        //SceneManager.LoadScene("TitleTentative");
    }

}