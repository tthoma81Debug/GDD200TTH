using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ZombieScript theZombieScript;

    void Start()
    {
        //get script on different game object
        theZombieScript = GameObject.FindGameObjectWithTag("zombie").GetComponent<ZombieScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //run like update but independent of frame rate
    private void FixedUpdate()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("zombie"))
        {
            //if the axe hits a zombie. then call its takeDamage function
            theZombieScript.takeDamage();

        }
    }
}
