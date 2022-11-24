using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject boiPrefab;
    private Transform spawnPoint;
    private bool isLocked = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateNewBoi(GameObject callingBoi)
    {
        Debug.Log("GenerateNewBoi called by " + callingBoi.gameObject.name + " at " + System.DateTime.UtcNow.Millisecond + " milliseconds");
        if (isLocked == false) //if it isn't locked yet, it is the first boi
        {
            //note. It is technically possible for the other boi to be so close in running time that twins do occur. This will probably be very unlikely
            isLocked = true; //lock it right away so the other one cannot also spawn
            Debug.Log("Lock acquired by " + callingBoi.gameObject.name);
            spawnPoint = GameObject.Find("SpawnPoint").transform; //get the spawn point
            Instantiate(boiPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("GernateNewBoi finished running at " + System.DateTime.UtcNow.Millisecond + " milliseconds for " + callingBoi.gameObject.name);
        }
        else //this happens when the second boy calls this function
        {
            Debug.Log(callingBoi.gameObject.name + " called the function but it was locked, so it must have been second. Not creating a second boi");
            isLocked = false; //reset the lock
        }

    }
}
