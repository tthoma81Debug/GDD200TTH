using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class woodcutterClick : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject theCameraObject;
    private Camera theCamera;
    private Vector3 targetPosition = new Vector3(0, 0, 0);
    private Transform thisObjectTransform;
    private Rigidbody2D physicsEngine;
    private Vector3 moveForce = new Vector3(0, 0, 0);
    void Start()
    {
        theCameraObject = GameObject.Find("Camera");
        theCamera = theCameraObject.GetComponent<Camera>();
        thisObjectTransform = this.gameObject.transform;
        physicsEngine = this.gameObject.GetComponent<Rigidbody2D>();
    }


    
    private void OnMouseUpAsButton()
    {
       // Debug.Log("Clicked Woodcutter!");
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("Mouse Clicked!");
           // Debug.Log("Update is running");
            //Debug.Log("Mouse is at " + Input.mousePosition);

            Vector3 clickSpot = theCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            //correct z
            clickSpot = new Vector3(clickSpot.x, clickSpot.y, 0);
          //  Debug.Log("Mouse is at " + Input.mousePosition);
          //  Debug.Log("which in world space is " + clickSpot);

            targetPosition = clickSpot;

            //also start timer
            StartCoroutine(firstCoroutine());

        }

        /*
        if(Input.GetKey(KeyCode.J))
        {
            //move towards target when holding j key. no physics
            //thisObjectTransform.position = Vector2.MoveTowards(thisObjectTransform.position, targetPosition, Time.deltaTime * 5f);

            //moveForce.x = ?
            //moveForce.y = ?


            //move with physics
            moveForce = (targetPosition - thisObjectTransform.position).normalized;
            Debug.Log("move force is " + moveForce);
            moveForce *= 1;
            physicsEngine.AddForce(moveForce);
        }
        */

        Vector3 distance = targetPosition - thisObjectTransform.position;
        //Debug.Log("Distance is " + distance);

        //determine if we are within 5 units left right of target and 1 units up down

        //Debug.Log("absolute x distance is " + Mathf.Abs(distance.x) + "absolute y distance is " + Mathf.Abs(distance.y));
        if (Mathf.Abs(distance.x) >= 0.25 && Mathf.Abs(distance.y) >= 0.25)
        {
            //can move
            thisObjectTransform.position = Vector2.MoveTowards(thisObjectTransform.position, targetPosition, Time.deltaTime * 5f);

        }
        else
        {
          //  Debug.Log("woah. We are within 5 units of that spot. I aint moving");
        }

        
    }

    public IEnumerator firstCoroutine()
    {

        while (true)
        {
            Debug.Log("In Coroutine first frame");
            //yield return null; //waits until next frame
            yield return new WaitForSeconds(4);
            Debug.Log("timer is up");
            
        }
    }
}
