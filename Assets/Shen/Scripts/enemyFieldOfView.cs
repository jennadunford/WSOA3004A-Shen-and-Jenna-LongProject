using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFieldOfView : MonoBehaviour
{
    public float fieldOfViewAngle = 90f;
    public float viewRange = 12f;

    public Transform fieldOfViewPoint;
    public Transform targetPoint;

    //public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = targetPoint.position - /*transform.position*/ fieldOfViewPoint.position;
        float sightAngle = Vector3.Angle(direction, fieldOfViewPoint.up);
        RaycastHit2D sightRay = Physics2D.Raycast(fieldOfViewPoint.position, direction, viewRange);

        if (sightAngle < fieldOfViewAngle / 2)
        {
            if(sightRay.collider != null)
            {
              if (sightRay.collider.CompareTag("Player") /*sightRay.collider.IsTouchingLayers(playerLayer)*/ )//the player has been spotted
              {
                Debug.Log("player spotted");
                Debug.DrawRay(fieldOfViewPoint.position, direction, Color.red);
                }
                else
                {
                    Debug.Log("player out of view");
                }
            }   
            /*else
            {
                Debug.Log("player out of view");
            }*/

            

        }
    }
}