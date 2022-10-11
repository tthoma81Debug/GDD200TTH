using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacscript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 rightMovement;
    public Vector3 leftMovement;
    public Vector3 upMovement;
    public Vector3 jump;

    public Rigidbody2D pacmanPhysicsEngine;
    public Animator woodcutterAnimator;

    int frameCount = 0;
    int speed = 2;
    float currentDownForce = 0f;
    private bool canJump = false;
    void Start()
    {
        Debug.Log("Start Ran");
        rightMovement = new Vector3(5, 0, 0);
        leftMovement = new Vector3(-5, 0, 0);
        upMovement = new Vector3(0, 15, 0);
        jump = new Vector3(0, 15, 0);

        //getting physics engine
        pacmanPhysicsEngine = GetComponent<Rigidbody2D>();
        //getting animator
        woodcutterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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
}
