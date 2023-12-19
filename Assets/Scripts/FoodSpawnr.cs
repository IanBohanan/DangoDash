using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnr : MonoBehaviour
{
    //The different spawners can hold a customer.
    private class Spawner
    {
        public Vector3 point; //Where the food will spawn
        public bool filled; //Whether there is a food in that spot or not
    }

    public GameObject foodPrefab; //The customer prefab to spawn

    [SerializeField]
    private List<Transform> spawnlocations; //Where should the customer spawn
    private List<Spawner> spawnPoints; //The actual spawn points used to create the customer line

    //used to check if all of the spots are filled later
    public int filledSpotCounters = 0;
    [SerializeField] GameObject tooMuchFoodText;

    private void OnEnable()
    {
        cookingPot.outputFood += attemptSpawnFood;
        Food.leftCounter += freeLineSpot; //Subscribe to customer's sitting event so it can free a spot in line when customer leaves line
        dayManager.dayReset += initSpawnPoints; //Reset the food spawns
    }

    private void OnDisable()
    {
        cookingPot.outputFood -= attemptSpawnFood;
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
        filledSpotCounters = 0;
        spawnPoints = new List<Spawner>();
        foreach (Transform loc in spawnlocations)
        {
            Spawner curSpawner = new Spawner();
            curSpawner.filled = false;
            curSpawner.point = loc.position;
            spawnPoints.Add(curSpawner);
        }
    }

    //Attempts to spawn a customer in the first available spawner in spawnPoints
    private void attemptSpawnFood(foodName foodMade)
    {

        filledSpotCounters = 0;

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (!spawnPoints[i].filled)
            {
                filledSpotCounters++;
                GameObject newFood = Instantiate(foodPrefab, spawnPoints[i].point, Quaternion.identity); //Create the new customer object
                Food foodcomponent = newFood.transform.GetComponent<Food>();
                foodcomponent.spotInLine = i; //Tell it which spot it was in line
                foodcomponent.setName(foodMade);
                spawnPoints[i].filled = true;

                if (filledSpotCounters >= 3)
                {
                    print("FoodSpawner: Too much food! SPawning text!");
                    tooMuchFoodText.SetActive(true);
                }
                return;
            }


            filledSpotCounters++;
            if (filledSpotCounters >= 3)
            {
                tooMuchFoodText.SetActive(true);
            }

        }
    }

    //Frees a spot in the spawnPoints list.
    //Params: int spot - the spot in line that should be freed.
    private void freeLineSpot(int spot,bool isDrink)
    {
        if(!isDrink)
        {
            if (spot >= 0)
            {
                spawnPoints[spot].filled = false;
                if (filledSpotCounters >= 3)
                {
                    filledSpotCounters = 2;
                }
                else
                {
                    filledSpotCounters--;
                }
            }
        }
    }
}
