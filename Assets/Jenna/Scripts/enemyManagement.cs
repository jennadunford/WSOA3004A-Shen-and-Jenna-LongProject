using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManagement : MonoBehaviour
{
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.playerCaught)
        {
            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponent<enemyFOVRotate>().fovPoint.transform.rotation = Quaternion.identity;   
               enemy.transform.position = enemy.GetComponent<jennaEnemyPatrol>().enemyPatrolPoints[0].transform.position;
                enemy.GetComponent<jennaEnemyPatrol>().patrolCount = 1;
            }
            playerMovement.playerCaught = false;
        }
        
    }
}
