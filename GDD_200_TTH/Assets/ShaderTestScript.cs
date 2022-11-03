using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTestScript : MonoBehaviour
{
    Renderer rend;
    Renderer woodCutterRend;
    public float myValue = 1.0f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        woodCutterRend = GameObject.Find("Woodcutter").GetComponent<Renderer>();

        // Use the Specular shader on the material
        woodCutterRend.material.shader = Shader.Find("TestShader");

        // Use the Specular shader on the material
        rend.material.shader = Shader.Find("TestShader");

        rend.material.SetFloat("_myValue", myValue);
        woodCutterRend.material.SetFloat("_myValue", 0.3f);
        Debug.Log("Set shader _myValue to " + rend.material.GetFloat("_myValue"));


        

       // rend.material.SetFloat("_myValue", myValue);
        Debug.Log("shader of woodcutter is " + woodCutterRend.material.GetFloat("_myValue"));
    }

    void Update()
    {
        // Animate the Shininess value
        float shininess = Mathf.PingPong(Time.time, 1.0f);
        rend.material.SetFloat("_Shininess", shininess);

    }
}
