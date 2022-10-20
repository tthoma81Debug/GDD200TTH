using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    private float deg = 90f;
    private GameObject go;
    private Vector3 cenLocal;
    private Rigidbody2D rb;
    private Vector3 rotateVector;
    private Transform cen;

    void Start()
    {
        go = this.gameObject;
        rotateVector = new Vector3(0, 0, 1);

        rb = go.GetComponent<Rigidbody2D>();
        // cenLocal = go.GetComponent<BoxCollider2D>().offset; // Center (local space)
        //cenLocal = GameObject.Find("Woodcutter").GetComponent<BoxCollider2D>().offset;
        cen = GameObject.Find("Woodcutter").transform;
    }


    private void Update()
    {
        Vector3 cenGlobal = go.transform.TransformPoint(cen.position); // Center (global space)

        go.transform.RotateAround(cen.position, rotateVector, deg * Time.deltaTime);
        Vector2 Point_1 = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        Vector2 Point_2 = new Vector2(cen.position.x, cen.position.y);
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x) * 180 / Mathf.PI;
        Debug.Log("angle is " + angle);


        //deg, or degrees, can be positive or negative. 
    }
}


/*other useful rotate stuff
 * 
 *      //A rotation 30 degrees around the y-axis
        Vector3 rotationVector = new Vector3(0, 30, 0);
        Quaternion rotation = Quaternion.Euler(rotationVector); //can pass in floats here too
        transform.rotation = rotation;

 * 
 */


