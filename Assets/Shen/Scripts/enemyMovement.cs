using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform[] enemyPatrolPoints;
    public float enemyMoveSpeed = 10f;
    bool reachedEnemyPoint = true;

    // Start is called before the first frame update
    void Start()
    {
        reachedEnemyPoint = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedEnemyPoint)
        {
            for (int i = 0; i < enemyPatrolPoints.Length; i++)
            {

                if (transform.position != enemyPatrolPoints[i].position)
                {
                    reachedEnemyPoint = false;
                    transform.position = Vector2.MoveTowards(transform.position, enemyPatrolPoints[i].position, enemyMoveSpeed * Time.deltaTime);
                }
                else if (i + 1 >= enemyPatrolPoints.Length)
                {
                    i = 0;
                }

                if (transform.position == enemyPatrolPoints[i].position)
                {
                    reachedEnemyPoint = true;
                }
                

            }
        }
        
    }

    
}
