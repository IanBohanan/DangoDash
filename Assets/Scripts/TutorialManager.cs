using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public enum Stages
    {
        Start, //Player reads start message
        WaitForKithcen, //Player is freely exploring the cafe. Kitchen arrow pointing to door
        ReadingKitchen, //Player is reading the text box in the kitchen
        MixingWhatever, //Player is messing around in the kitchen.
        WaitForDrinks, //Player in restraunt with arrow pointing to drink mixer
        ReadingDrinks, //Player reading slide in drink station
        DrinkingWhatever, //Player is messing around in the drink station
        LearningSpaceLimitation, //Player is reading slide about limited space.
        LearningCustomers, //Player is reading slide about customer dragging
        FirstCustomerArrives, //First customer has appeared
        CustomerSatDown, 
        CustomerFedWrong, //Customer was fed wrong! Player reading wrong slide
        CustomerSuccessShowClock, //Customer was fed right! Player reading correct slide
        ReadRepbar, //Player reading about repBar
        ReadFInal //Player finishing final slide
    }

    public Stages curStage = Stages.Start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseUp()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
