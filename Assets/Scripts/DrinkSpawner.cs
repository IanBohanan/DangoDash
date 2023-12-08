using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkSpawner : MonoBehaviour
{
    //The different spawners can hold a customer.
    private class Spawner
    {
        public Vector3 point; //Where the food will spawn
        public bool filled; //Whether there is a food in that spot or not
    }

    public GameObject drinkPrefab; //The customer prefab to spawn

    [SerializeField]
    private List<Transform> spawnlocations; //Where should the customer spawn
    private List<Spawner> spawnPoints; //The actual spawn points used to create the customer line

    private void OnEnable()
    {
        DrinkingCup.outputDrink+= attemptSpawnDrink;
        Food.leftCounter += freeLineSpot; //Subscribe to customer's sitting event so it can free a spot in line when customer leaves line
        dayManager.dayReset += initSpawnPoints; //Reset the food spawns
    }

    private void OnDisable()
    {
        DrinkingCup.outputDrink -= attemptSpawnDrink;
        Food.leftCounter -= freeLineSpot;
        dayManager.dayReset -= initSpawnPoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        initSpawnPoints(); //Create the food spawn points
    }

    //Creates the spawn locations based on how many spawnLocations were given
    //Makes them all empty and assigns them locations based on each spawnLocation
    private void initSpawnPoints()
    {
        spawnPoints = new List<Spawner>();
        foreach (Transform loc in spawnlocations)
        {
            Spawner curSpawner = new Spawner();
            curSpawner.filled = false;
            curSpawner.point = loc.position;
            spawnPoints.Add(curSpawner);
        }
    }


    public int filledSpotCounter;
    [SerializeField] GameObject tooMuchFoodText;

    //Attempts to spawn a customer in the first available spawner in spawnPoints

    private void attemptSpawnDrink(foodName drinkMade)
    {
        print("DrinkerSpawner: Spawned drink on counter!");
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (!spawnPoints[i].filled)
            {
                filledSpotCounter++;
                GameObject newFood = Instantiate(drinkPrefab, spawnPoints[i].point, Quaternion.identity); //Create the new customer object
                Food foodcomponent = newFood.transform.GetComponent<Food>();
                foodcomponent.spotInLine = i; //Tell it which spot it was in line
                foodcomponent.setName(drinkMade);
                spawnPoints[i].filled = true;

                if (filledSpotCounter >= 3)
                {
                    tooMuchFoodText.SetActive(true);
                }

                return;
            }

            
        }
        filledSpotCounter++;
        if (filledSpotCounter >= 3)
        {
            tooMuchFoodText.SetActive(true);
        }

    }

    //Frees a spot in the spawnPoints list.
    //Params: int spot - the spot in line that should be freed.
    private void freeLineSpot(int spot)
    {
        if (spot >= 0)
        {
            spawnPoints[spot].filled = false;
            if (filledSpotCounter >= 3)
            {
                filledSpotCounter = 2;
            }
            else
            {
                filledSpotCounter--;
            }
        }

    }
}
