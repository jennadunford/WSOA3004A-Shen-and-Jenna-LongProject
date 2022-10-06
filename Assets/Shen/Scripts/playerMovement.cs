using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //public Animator playerAnimator;

    public Rigidbody2D playerRigidBody;

    float moveHori = 0f;
    public float moveSpeed = 10f;
    public static float vertMovement;
    public float vertSpeed = 10f;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

        //playerAnimator.SetFloat("Speed", Mathf.Abs(moveHori));                                      //setting the speed parameter for when the movement animation needs to be called
    }


    
}
