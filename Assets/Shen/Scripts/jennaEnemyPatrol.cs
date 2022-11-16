using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jennaEnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] enemyPatrolPoints;
    public float enemyMoveSpeed = 10f;
    public int patrolCount = 1;


    public bool patrolling = true;


    // Update is called once per frame
    //we'll have a counter that goes from 0 to 3 and then back to zero
    //each time the enemy reaches a transform, counter will increase by 1 until it reaches three it will become zero again
    void Update()
    {
        if (patrolling && !enemyFieldOfView.TartinRange)
        {
            if (patrolCount >= enemyPatrolPoints.Length)
            {
                patrolCount = 0;
                patrolling = true;
                //Debug.Log("reset to zero");
            }
            transform.position = Vector2.MoveTowards(transform.position, enemyPatrolPoints[patrolCount].position, enemyMoveSpeed * Time.deltaTime);
            //direction = (enemyPatrolPoints[patrolCount].position - transform.position).normalized;
            //gameObject.GetComponent<Rigidbody2D>().velocity = direction * enemyMoveSpeed * Time.deltaTime;
            if (transform.position == enemyPatrolPoints[patrolCount].position)
            {
                //Debug.Log("Reached position 0.0");
                patrolCount++;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "turnPoint")
        {
            patrolling = false;
            rotateAround();
        }
    }

    public void rotateAround()
    {
        // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(180,Vector3.left), 0.1f);
        //transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        //gameObject.GetComponent<enemyFOVRotate>().rotateEnemy();
        //Debug.Log("should rotate");
        Invoke("returnPatrol", 3f);
    }

    public void returnPatrol()
    {
        patrolling = true;
    }
}


