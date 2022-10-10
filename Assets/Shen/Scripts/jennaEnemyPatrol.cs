using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jennaEnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] enemyPatrolPoints;
    public float enemyMoveSpeed = 100f;
    public int patrolCount = 1;




    // Update is called once per frame
    //we'll have a counter that goes from 0 to 3 and then back to zero
    //each time the enemy reaches a transform, counter will increase by 1 until it reaches three it will become zero again
    void Update()
    {
        if(patrolCount >= enemyPatrolPoints.Length)
        {
            patrolCount = 0;
            //Debug.Log("reset to zero");
        }
        transform.position = Vector2.MoveTowards(transform.position, enemyPatrolPoints[patrolCount].position, enemyMoveSpeed * Time.deltaTime);
        if(transform.position == enemyPatrolPoints[patrolCount].position)
        {
            //Debug.Log("Reached position 0.0");
            patrolCount++;
        }
    }
}
