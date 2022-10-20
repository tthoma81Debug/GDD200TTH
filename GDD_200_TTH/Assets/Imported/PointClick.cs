using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 targetPosition;
    public Camera theCamera;
    public Transform thingMoving;
    public Vector3 clickSpot;
    void Start()
    {
        thingMoving = GameObject.Find("Woodcutter").GetComponent<Transform>();
        theCamera = GameObject.Find("Camera").GetComponent<Camera>();
        targetPosition = new Vector3(0, 0, 0);

    }



// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(Input.mousePosition);
           // clickSpot = Input.mousePosition;
            //clickSpot.z = theCamera.nearClipPlane;
           // targetPosition = theCamera.ScreenToWorldPoint(Input.mousePosition);
           // Debug.Log(targetPosition);


                //RaycastHit raycastHit;
               // Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);
           // Debug.Log("ray is " + ray);
            
            RaycastHit2D hit = Physics2D.Raycast(theCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.up);



                    if (hit.transform != null)
                    {
                    //Our custom method. 
                    //CurrentClickedGameObject(raycastHit.transform.gameObject);
                    Debug.Log("hit " + hit.transform.name);
                    Debug.Log(hit.transform.position);
                    targetPosition = theCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, theCamera.nearClipPlane));
                Debug.Log("target position" + targetPosition);
                    }
            




        }

        if(Input.GetKey(KeyCode.J))
        {
            thingMoving.position = Vector2.MoveTowards(thingMoving.transform.position, targetPosition, Time.deltaTime * 5f);
        }

        
    }


}
