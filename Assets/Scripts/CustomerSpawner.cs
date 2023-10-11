using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab; //The customer prefab to spawn
    public Transform customerSpawnPoint; //Where should the customer spawn
    public float timeUntilSpawn = 5.0f;
    private float timeLeft; //Time in seconds until something happens

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeUntilSpawn;
    }

    //Updates the timer every frame.
    //Once the timer reaches zero, the customer leaves and notifies the game that they left
    private void updateTimer()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            timeLeft = timeUntilSpawn;
            GameObject nextCustomer = Instantiate(customerPrefab, customerSpawnPoint.transform.position, Quaternion.identity); //Create the new customer object
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
    }
}
