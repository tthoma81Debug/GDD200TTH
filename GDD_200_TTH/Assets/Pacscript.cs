using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pacscript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 rightMovement;
    public Vector3 leftMovement;
    public Vector3 upMovement;
    public Vector3 jump;

    public Rigidbody2D pacmanPhysicsEngine;
    public Animator woodcutterAnimator;
    private AudioSource axeSound;
    private Camera actualCamera;
    private Rigidbody2D zombiePhysics;

    int frameCount = 0;
    int speed = 2;
    float currentDownForce = 0f;
    bool canMove = true;
    private bool canJump = false;
    bool coroutineStarted = false;
    Vector3 clickSpot = new Vector3(0, 0, 0);
    void Start()
    {
        Debug.Log("Start Really Did Run");
        rightMovement = new Vector3(5, 0, 0);
        leftMovement = new Vector3(-5, 0, 0);
        upMovement = new Vector3(0, 15, 0);
        jump = new Vector3(0, 15, 0);

        //getting physics engine
        pacmanPhysicsEngine = GetComponent<Rigidbody2D>();
        //getting animator
        woodcutterAnimator = GetComponent<Animator>();
        axeSound = GameObject.Find("AxeSound").GetComponent<AudioSource>();
        actualCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //left clicked somehwere
            Debug.Log("Clicked at position " + Input.mousePosition);
            clickSpot = actualCamera.ScreenToWorldPoint(Input.mousePosition); //converting to world space
            //correct the z
            clickSpot = new Vector3(clickSpot.x, clickSpot.y, 0);

            Debug.Log("which is " + clickSpot + " In world space");

            //start coroutine
            if(coroutineStarted == false)
            {
                StartCoroutine(firstCoroutine());
                coroutineStarted = true;
            }
             

            /*
            IEnumerator coroutineReference = firstCoroutine();
            StartCoroutine(coroutineReference);
            StopCoroutine(coroutineReference);
            */
            

        }

        Vector3 distanceVector = clickSpot - this.transform.position;

        /* non physics based movement

        Debug.Log("Distance is " + distanceVector);
        if (Mathf.Abs(distanceVector.x) >= 1f && Mathf.Abs(distanceVector.y) >= 1f)
        {
            // set target
            this.transform.position = Vector3.MoveTowards(this.transform.position, clickSpot, Time.deltaTime * 5f);
          
        }
        else
        {
            //too close on either x or y
        }
        
        */


        //physics based movement

        Vector3 direction = distanceVector.normalized;
        Vector3 moveForce = direction * 3;

        pacmanPhysicsEngine.AddForce(moveForce);



        /*
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right arrow pressed");
            transform.Translate(rightMovement * Time.deltaTime * speed);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(leftMovement * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(upMovement * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(downMovement);
        }
        //Debug.Log("Update ran " + frameCount + " Times");
        //frameCount++;

    */

        //controller input

        
        
        Debug.Log(Input.GetAxis("Horizontal"));
        float controllerInput = Input.GetAxis("Horizontal");
        float speed = 8;
        float newXInput = controllerInput * speed;

        Vector2 controllerSpeed = new Vector2(newXInput, pacmanPhysicsEngine.velocity.y);
        pacmanPhysicsEngine.velocity = controllerSpeed;
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
          //  Debug.Log("Right arrow pressed");
            currentDownForce = pacmanPhysicsEngine.velocity.y;
            pacmanPhysicsEngine.velocity = new Vector3(rightMovement.x, pacmanPhysicsEngine.velocity.y, 0);


            //wont work. unity doesn't like it 
            //pacmanPhysicsEngine.velocity.y = currentDownForce;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
           
            currentDownForce = pacmanPhysicsEngine.velocity.y;
            pacmanPhysicsEngine.velocity = new Vector3(leftMovement.x, pacmanPhysicsEngine.velocity.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(canJump)
            {
                pacmanPhysicsEngine.AddForce(jump, ForceMode2D.Impulse);
                canJump = false;
            }

            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(downMovement);
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            //melee attack
            //want to say something like Animation.Play(attack);
            woodcutterAnimator.Play("MeleeAttack");
            axeSound.Play();


        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            //cast a ray
            Vector2 rayOrigin = new Vector2(this.transform.position.x + 1.5f, this.transform.position.y);

            //apply layer mask

            int theLayerMask = LayerMask.GetMask("enemy");

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, Mathf.Infinity, theLayerMask);
            Debug.DrawRay(rayOrigin, new Vector3(999,0,0), Color.green, 5);


            if (hit == false)
            {
                Debug.Log("Cast a ray. Didn't hit anything");
            }
            else
            {
                Debug.Log("Hit!. Looks like we hit" + hit.transform.gameObject.name);

                //if it is a zombie
                if(hit.transform.gameObject.name == "zombie")
                {
                    Vector3 distance = hit.transform.position - this.transform.position;
                    Vector3 grappleForce = new Vector3(distance.x * -1, 2, 0);
                    zombiePhysics = hit.transform.gameObject.GetComponent<Rigidbody2D>();
                    zombiePhysics.AddForce(grappleForce, ForceMode2D.Impulse);
                }
            }
        }


        //Debug.Log("Update ran " + frameCount + " Times");
        //frameCount++;





    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "zombie")
        {
            //Debug.Log(collision.gameObject.name);
            //Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("ground"))
        {
            //pacman hit the ground
            canJump = true;
        }

    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("you clicked on " + this.gameObject.name);
    }
     
    public IEnumerator firstCoroutine()
    {

        while(true)
        {
            Debug.Log("yaaay. coroutine ran. tick tock");
            yield return new WaitForSeconds(4);
            Debug.Log("yaaay. timer is up");
            //SceneManager.LoadScene("Level2");
        }

    }

    public void runWhenClicked(int whichButton)
    {
        Debug.Log("yaaaay! button was clicked. which is the button numbered " + whichButton);
        GameObject.Find("Panel").SetActive(false);
    }
}
