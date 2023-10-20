using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public enum foodName
{
    BOBA,
    BROKENFISH,
    CATBAG,
    CATBISCUITS,
    CATBOX,
    FULLFISH,
    THICKDRINK,
    TAIYAKI,
    TRASH
}

public class Food : MonoBehaviour
{
    public foodName name;

    //Generates a random food for the desired food
    //Todo: test if this misses the last food icon? Might be one off?
    public void generateName()
    {
        name = (foodName)UnityEngine.Random.Range(0, Enum.GetValues(typeof(foodName)).Cast<int>().Max());
    }

    public void setName(foodName r_name)
    {
        name = r_name;
    }
}
