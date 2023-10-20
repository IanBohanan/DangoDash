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

    private void OnEnable()
    {
        cookingPot.outputFood += attemptSpawnFood;
        Food.leftCounter += freeLineSpot; //Subscribe to customer's sitting event so it can free a spot in line when customer leaves line
    }

    private void OnDisable()
    {
        cookingPot.outputFood += attemptSpawnFood;
        Food.leftCounter -= freeLineSpot;
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

    //Attempts to spawn a customer in the first available spawner in spawnPoints
    private void attemptSpawnFood(foodName foodMade)
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (!spawnPoints[i].filled)
            {
                GameObject newFood = Instantiate(foodPrefab, spawnPoints[i].point, Quaternion.identity); //Create the new customer object
                Food foodcomponent = newFood.transform.GetComponent<Food>();
                foodcomponent.spotInLine = i; //Tell it which spot it was in line
                foodcomponent.setName(foodMade);
                spawnPoints[i].filled = true;
                return;
            }
        }
    }

    //Frees a spot in the spawnPoints list.
    //Params: int spot - the spot in line that should be freed.
    private void freeLineSpot(int spot)
    {
        if(spot >= 0)
        {
            print("FoodSpawner: Freeing counter spot" + spot);
            spawnPoints[spot].filled = false;
        }

    }
}
