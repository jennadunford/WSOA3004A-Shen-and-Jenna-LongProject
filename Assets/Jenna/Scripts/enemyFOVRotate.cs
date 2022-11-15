using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFOVRotate : MonoBehaviour
{
    Vector3 currentDir;
    Vector3 prevPos;
    public GameObject fovPoint;

    public float speed = 2f;

    public bool distracted = false;

   // public Transform distractedPoint;
    // Start is called before the first frame update
    void Start()
    {
        prevPos = fovPoint.transform.position;
        currentDir = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.GetComponent<jennaEnemyPatrol>().patrolling)
        {
            if (fovPoint.transform.position != prevPos)
            {
                currentDir = (fovPoint.transform.position - prevPos).normalized;
                prevPos = fovPoint.transform.position;
                //Debug.Log("direction: " + currentDir);

            }
            //Quaternion rotation = Quaternion.AngleAxis(currentDir.z,Vector3.up);
            //fovPoint.transform.rotation = rotation;

            var angle = Mathf.Atan2(currentDir.y, currentDir.x) * Mathf.Rad2Deg;
            fovPoint.transform.rotation = Quaternion.Lerp(fovPoint.transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), 0.1f);
        }

        if (!gameObject.GetComponent<jennaEnemyPatrol>().patrolling && !distracted)
        {
            var ang = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;
           // fovPoint.transform.rotation = Quaternion.Lerp(fovPoint.transform.rotation, Quaternion.AngleAxis(-200, Vector3.forward), 0.1f);
            fovPoint.transform.RotateAround(-Vector3.forward, 2f*Time.deltaTime);
        }

        if (distracted)
        {
            Debug.Log("Enemy has been distracted");
        }
    }

    public void rotateToDistraction(Transform distractionPoint)
    {
        gameObject.GetComponent<jennaEnemyPatrol>().patrolling = false;
        Debug.Log("Here enemy must rotate towards where the whistle was heard");
        Vector3 newDirection;
        Vector3 oldDirection;
        oldDirection = transform.position;
        newDirection = (distractionPoint.transform.position - oldDirection).normalized;
        var angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        fovPoint.transform.rotation = Quaternion.Lerp(fovPoint.transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), 0.01f);
        Invoke("returnPatrolNonDistracted", 5f);


    }

    public void returnPatrolNonDistracted()
    {
        distracted = false;
        gameObject.GetComponent<jennaEnemyPatrol>().patrolling = true;
    }
}
