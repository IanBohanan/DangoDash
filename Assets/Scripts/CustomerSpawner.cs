
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    //used to play the doorbell sound
    [SerializeField] AudioSource doorbell;

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
    private bool isTicking = true;

    //Difficulty-related vars that influence customer prefabs when spawned
    private float customerLineTime = 20f; //How long customers will wait at the door
    private float customerTableTime = 40f; //How long customers will wait at a table
    private float customerMinSpawnTime = 6.0f; //How long to wait (minimum) until another customer comes in
    private float customerMaxSpawnTime = 10.0f; //How long to wait (maximum) until another customer comes in

    private void OnEnable()
    {
        Customer.leftLine += freeLineSpot; //Subscribe to customer's sitting event so it can free a spot in line when customer leaves line
        dayManager.dayReset += startOfDay;
        StardewClock.dayOver += endOfDay;
    }

    private void OnDisable()
    {
        Customer.leftLine -= freeLineSpot;
        dayManager.dayReset -= startOfDay;
        StardewClock.dayOver -= endOfDay;
    }

    private void endOfDay()
    {
        isTicking = false;
        timeLeft = timeUntilSpawn;
    }

    private void startOfDay()
    {
        isTicking = true;
        timeLeft = timeUntilSpawn;
        initSpawnPoints();
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
            timeLeft = Random.Range(customerMinSpawnTime, customerMaxSpawnTime);
            attemptSpawnCustomer();
        }
    }

    //Modifies one of the self-labeled "difficulty" variables to make game harder
    public void increaseDifficulty()
    {
        int randomNumber = Random.Range(1, 5); //Random exlcudes the second number, so generates num from 1 to 4

        switch (randomNumber)
        {
            case 1:
                if(customerLineTime > 10.0f)
                {
                    customerLineTime -= 5f;
                }
                break;
            case 2:
                if (customerTableTime > 20.0f)
                {
                    customerLineTime -= 5f;
                }
                break;
            case 3:
                if(customerMinSpawnTime > 3.0f && customerMinSpawnTime < customerMaxSpawnTime)
                {
                    customerMinSpawnTime -= 1f;
                }
                break;
            case 4:
                if(customerMaxSpawnTime > 5.0f && customerMaxSpawnTime > customerMinSpawnTime)
                {
                    customerMaxSpawnTime -= 1f;
                }
                break;
            default:
                // code block
                break;
        }
    }
    
    //Attempts to spawn a customer in the first available spawner in spawnPoints
    private void attemptSpawnCustomer()
    {
        for(int i=0;i<spawnPoints.Count;i++)
        {
            if (!spawnPoints[i].filled)
            {
                GameObject nextCustomerObject = Instantiate(customerPrefab, spawnPoints[i].point, Quaternion.identity); //Create the new customer object
                Customer nextCustomer = nextCustomerObject.transform.GetComponent<Customer>();
                nextCustomer.spotInLine = i; //Tell it which spot it was in line
                nextCustomer.lineTimer = customerLineTime;
                nextCustomer.tableTimer = customerTableTime;
                spawnPoints[i].filled = true;
                doorbell.Play();
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
        if(isTicking)
        {
            updateTimer();
        }
    }
}
