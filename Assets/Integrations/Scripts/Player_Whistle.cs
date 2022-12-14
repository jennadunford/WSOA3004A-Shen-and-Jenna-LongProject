using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Whistle : MonoBehaviour
{
    public Transform whistlePoint;
    public float whistleRange = 9f;
    public LayerMask enemyLayer;
    public bool whistling = false;

    
    public float totalWhistleTime = 1f;
    public float remainingWhistleTime = 0f;
    //public bool dashing = false;
    public float whistleCoolDownTime = 0.5f;
    public bool whistleCoolDownOver = true;

    public GameObject playerObject;
    public GameObject circleRange;

  

    public Transform newWhistlePosition;

    public GameObject audioManager;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("Audio Manager");
        circleRange.SetActive(false);
        remainingWhistleTime = totalWhistleTime;
        whistling = false;
        whistleCoolDownOver = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!whistling && (Input.GetKeyDown(KeyCode.K)) || Input.GetKeyDown("joystick button 3"))
        {
            if (whistleCoolDownOver && remainingWhistleTime == totalWhistleTime)
            {
                whistling = true;
                newWhistlePosition = transform;
                audioManager.GetComponent<audioManagement>().playerWhistle();
                //playerObject.GetComponent<SpriteRenderer>().color = Color.green;
                circleRange.SetActive(true);

            }
        }


        if (remainingWhistleTime <= 0)
        {
            //playerRigidBody.velocity = new Vector2(0f, 0f);
            whistling = false;
            remainingWhistleTime = totalWhistleTime;
            //dashCoolDownTime -= Time.deltaTime;
            whistleCoolDownOver = false;
            playerObject.GetComponent<SpriteRenderer>().color = Color.white;
            circleRange.SetActive(false);
        }

        if (whistling)
        {
            //need to make this an if condition based on enemy tag as well
            Collider2D[] enemies = Physics2D.OverlapCircleAll(whistlePoint.position, whistleRange, enemyLayer);
           
            foreach (Collider2D distractedEnemy in enemies)
            {
                Debug.Log(distractedEnemy.gameObject.name + " is distracted now");
                distractedEnemy.GetComponentInParent<enemyFOVRotate>().rotateToDistraction(newWhistlePosition);
                distractedEnemy.GetComponentInParent<enemyFOVRotate>().distracted = true;
            }

            remainingWhistleTime -= Time.deltaTime; //fixed delta time is for fixed update, update just uses delta time
            
        }

        if (!whistleCoolDownOver)
        {
            whistleCoolDownTime -= Time.deltaTime;
        }

        if (whistleCoolDownTime <= 0)
        {
            whistleCoolDownOver = true;
            whistleCoolDownTime = 0.5f;
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (whistlePoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(whistlePoint.position, whistleRange);
    }

}
