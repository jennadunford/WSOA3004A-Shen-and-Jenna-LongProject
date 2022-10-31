using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFOVRotate : MonoBehaviour
{
    Vector3 currentDir;
    Vector3 prevPos;
    public GameObject fovPoint;

    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        prevPos = fovPoint.transform.position;
        currentDir = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fovPoint.transform.position!= prevPos)
        {
            currentDir = (fovPoint.transform.position - prevPos).normalized;
            prevPos = fovPoint.transform.position;
            //Debug.Log("direction: " + currentDir);
           
        }
        //Quaternion rotation = Quaternion.AngleAxis(currentDir.z,Vector3.up);
        //fovPoint.transform.rotation = rotation;

        var angle = Mathf.Atan2(currentDir.y, currentDir.x) * Mathf.Rad2Deg ;
        fovPoint.transform.rotation = Quaternion.Lerp(fovPoint.transform.rotation,Quaternion.AngleAxis(angle-90, Vector3.forward),0.1f);

    }
}
