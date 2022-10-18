using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    Light2D theCandle;
    void Start()
    {
        theCandle = GameObject.Find("Candle").GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        theCandle.intensity = 1;
    }
}
