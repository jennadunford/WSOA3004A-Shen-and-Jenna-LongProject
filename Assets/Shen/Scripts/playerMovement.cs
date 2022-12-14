using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    //public Animator playerAnimator;

    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;

    float moveHori = 0f;
    public float moveSpeed = 10f;
    public static float vertMovement;
    public float vertSpeed = 10f;

    public float lastMoveHori;
    public float lastMoveVert;
    public float totalDashTime = 0.1f;
    public float remainingDashTime = 0f;
    public float dashSpeed = 20f;
    public bool dashing = false;
    public Vector2 playerVel;
    public float dashCoolDownTime = 0.2f;
    public bool coolDownOver = true;

    public static bool playerCaught = false;

    Vector2 playerDirection;


    // Start is called before the first frame update
    void Start()
    {
        playerCaught = false;
        remainingDashTime = totalDashTime;
        lastMoveHori = 1f;
        lastMoveVert = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        playerVel = playerRigidBody.velocity;

        playerDirection = new Vector2(lastMoveHori, lastMoveVert);

        //playerAnimator.SetFloat("horiSpeed", playerVel.y);
        //playerAnimator.SetFloat("vertSpeed", playerVel.x);
        playerAnimator.SetFloat("horiSpeed", moveHori);
        playerAnimator.SetFloat("vertSpeed", vertMovement);


        if (moveHori != 0)
        {
            lastMoveHori = moveHori;
        }

        if (vertMovement != 0)
        {
            lastMoveVert = vertMovement;
        }

        if (moveHori == 0 && vertMovement != 0)
        {
            lastMoveHori = 0;
        }

        if (moveHori != 0 && vertMovement == 0)
        {
            lastMoveVert = 0;
        }

        /*if (lastMoveHori < 0)
        {
            lastMoveHori = -1;
        }

        if (lastMoveHori > 0)
        {
            lastMoveHori = 1;
        }

        if (lastMoveVert < 0)
        {
            lastMoveVert = -1;
        }

        if (lastMoveVert > 0)
        {
            lastMoveVert = 1;
        }*/

        if (!dashing && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 1")))
        {
            
            if (coolDownOver && remainingDashTime == totalDashTime)
            {
                //remainingDashTime -= Time.deltaTime;
                dashing = true;
                //playerRigidBody.velocity = new Vector2(lastMoveVert * dashSpeed, lastMoveHori * dashSpeed);
                playerAnimator.SetBool("Dash", true);
            }

            

            /*if (remainingDashTime > 0 && remainingDashTime < totalDashTime)
            {

            }*/
        }

        /*if (dashing)
        {
            playerRigidBody.velocity = new Vector2(lastMoveHori * dashSpeed, lastMoveVert * dashSpeed);
            
            remainingDashTime -= Time.deltaTime;
            //playerRigidBody.velocity = new Vector2(50f, 50f);
        }*/

        if (remainingDashTime <= 0)
        {
            playerRigidBody.velocity = new Vector2(0f, 0f);
            dashing = false;
            playerAnimator.SetBool("Dash", false);
            remainingDashTime = totalDashTime;
            //dashCoolDownTime -= Time.deltaTime;
            coolDownOver = false;
        }

        if (!coolDownOver)
        {
            dashCoolDownTime -= Time.deltaTime;
        }

        if (dashCoolDownTime <=0)
        {
            coolDownOver = true;
            dashCoolDownTime = 0.2f;
        }

        //vertMovement = Input.GetAxisRaw("Vertical");

        /*if (enemyObject.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            enemyObject.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
            enemyObject.transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
        }*/

 
    }

    private void FixedUpdate()
    {
        moveHori = Input.GetAxisRaw("Horizontal");                                                   //movement using horizontal axis and rigidbody of gameobject
        playerRigidBody.velocity = new Vector2(moveHori * moveSpeed, playerRigidBody.velocity.y);

        vertMovement = Input.GetAxisRaw("Vertical");
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, vertMovement * vertSpeed);


        if (dashing)
        {
            /*if (lastMoveHori != 0 && lastMoveVert != 0)
            {
                playerRigidBody.velocity = new Vector2(lastMoveHori *dashSpeed/2, lastMoveVert *dashSpeed/2);

            }
            else
            {
                playerRigidBody.velocity = new Vector2(lastMoveHori * dashSpeed, lastMoveVert * dashSpeed);
            }*/
            playerRigidBody.velocity = new Vector2(lastMoveHori * (40 / playerDirection.magnitude), lastMoveVert * (40 / playerDirection.magnitude));
            //playerRigidBody.velocity = new Vector2(lastMoveHori * dashSpeed, lastMoveVert * dashSpeed);

            remainingDashTime -= Time.fixedDeltaTime; //fixed delta time is for fixed update, update just uses delta time
            //playerRigidBody.velocity = new Vector2(50f, 50f);
        }

        //playerAnimator.SetFloat("Speed", Mathf.Abs(moveHori));                                      
        //setting the speed parameter for when the movement animation needs to be called
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "steam")
        {
            transform.position = new Vector3(transform.position.x - 15, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        }
    }

}
