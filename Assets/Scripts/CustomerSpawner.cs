using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    //The different spawners can hold a customer.
    private class Spawner
    {
        public Vector3 point; //Where the customer will spawn
        public bool filled; //Whether there is a customer in that spot or not
    }

    public GameObject customerPrefab; //The customer prefab to spawn

    [SerializeField]
    private List<Transform> spawnlocations; //Where should the customer spawn
    private List<Spawner> spawnPoints; //The actual spawn points used to create the customer line

    public float timeUntilSpawn = 5.0f;
    public float timeLeft; //Time in seconds until something happens

    private void OnEnable()
    {
        Customer.leftLine += freeLineSpot; //Subscribe to customer's sitting event so it can free a spot in line when customer leaves line
    }

    private void OnDisable()
    {
        Customer.leftLine -= freeLineSpot;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeUntilSpawn;
        initSpawnPoints(); //Create the customer spawn points

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

    //Updates the timer every frame.
    //Once the timer hits zero, attempt to spawn a customer in the line. 
    //Finally reset the timer
    private void updateTimer()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            timeLeft = timeUntilSpawn;
            attemptSpawnCustomer();
        }
    }
    
    //Attempts to spawn a customer in the first available spawner in spawnPoints
    private void attemptSpawnCustomer()
    {
        for(int i=0;i<spawnPoints.Count;i++)
        {
            if (!spawnPoints[i].filled)
            {
                GameObject nextCustomer = Instantiate(customerPrefab, spawnPoints[i].point, Quaternion.identity); //Create the new customer object
                nextCustomer.transform.GetComponent<Customer>().spotInLine = i; //Tell it which spot it was in line
                spawnPoints[i].filled = true;
                return;
            }
        }
    }

    //Frees a spot in the spawnPoints list.
    //Params: int spot - the spot in line that should be freed.
    private void freeLineSpot(int spot)
    {
        spawnPoints[spot].filled = false;
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
    }
}
