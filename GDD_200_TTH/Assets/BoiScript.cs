using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiScript : MonoBehaviour
{
    // Start is called before the first frame update

    private BoiScript otherBoiScript;
    private GameManagerScript gameManagerScript;
    void Start()
    {
        otherBoiScript = GameObject.Find("BoiTwo").GetComponent<BoiScript>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();



        //both bois will run this script and will both call their own copies of breedTest().
        //both will call the same function in the game manager script. To prevent two bois, we lock it after the first one
        breedTest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void breedTest()
    {
        //it will pass a reference to itself 
        gameManagerScript.generateNewBoi(this.gameObject);
    }
}
