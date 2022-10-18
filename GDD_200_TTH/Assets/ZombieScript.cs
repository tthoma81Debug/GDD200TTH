using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 5;
    AudioSource zombieImpact;
    void Start()
    {
        zombieImpact = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        health--;

        Debug.Log("Zombie Hit. Health is now " + health);
        zombieImpact.Play();

        if(health <=0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
