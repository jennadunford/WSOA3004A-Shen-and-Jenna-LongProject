using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyFieldOfView : MonoBehaviour
{
    public float fieldOfViewAngle = 90f;
    public float viewRange = 6f;

    public Transform fieldOfViewPoint;
    public Transform targetPoint;

    public LayerMask ignoreEnemyLayer;

    public Transform playerRespawnPoint;
    public GameObject player;
    public GameObject spottedText;

    public GameObject audioManager;

    private GameObject seenTart;

    public static bool TartinRange = false;


    //public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        spottedText = GameObject.Find("caughtPanel");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = targetPoint.position - /*transform.position*/ fieldOfViewPoint.position;
        float sightAngle = Vector3.Angle(direction, fieldOfViewPoint.up);
        RaycastHit2D sightRay = Physics2D.Raycast(fieldOfViewPoint.position, direction, viewRange, ~ignoreEnemyLayer);

        if (sightAngle < fieldOfViewAngle / 2)
        {
            if(sightRay.collider != null)
            {
              if ((sightRay.collider.CompareTag("Player") && !playerMovement.playerCaught) /*sightRay.collider.IsTouchingLayers(playerLayer)*/ )//the player has been spotted
              {
                //Debug.Log("player spotted");
                Debug.DrawRay(fieldOfViewPoint.position, direction, Color.red);



                    //sound play here
                    audioManager.GetComponent<audioManagement>().playerCaught();
                    playerMovement.playerCaught = true;
                    pauseAll();
                    //Invoke("resetPlayer", 1f);
                   // spottedText.SetActive(true);
                    //player.GetComponent<playerCollection>().resetEmeralds();
                    //player.transform.position = playerRespawnPoint.position;
                }
                
            }   
           

            

        }
        if(seenTart && !playerMovement.playerCaught)
        {
            TartinRange = true;
            gameObject.GetComponent<jennaEnemyPatrol>().patrolling = false;
        }
    }

    public void resetPlayer()
    {
        player.transform.position = playerRespawnPoint.position;
        //spottedText.SetActive(false);
        foreach (Image im in spottedText.GetComponentsInChildren<Image>())
        {
            im.enabled = false;
        }
        spottedText.GetComponentInChildren<Text>().enabled = false;
        gameObject.GetComponent<jennaEnemyPatrol>().patrolling = true;
        enemyManagement.resetEnemies = true;
        playerMovement.playerCaught = false;
        player.GetComponent<collectionScript>().InventoryHandlerGlobal.GetComponent<inventoryHandler>().loseItemsFromScene(SceneManager.GetActiveScene().buildIndex);
       
        //resetting enemy
     
       // gameObject.GetComponent<enemyFOVRotate>().fovPoint.transform.rotation = Quaternion.identity;
    }

    public void pauseAll()
    {

        //spottedText.SetActive(true);
        foreach(Image im in spottedText.GetComponentsInChildren<Image>())
        {
            im.enabled = true;
        }
       // spottedText.GetComponent<Image>().enabled = true;
       // spottedText.GetComponentInChildren<Image>().enabled = true;
        
        spottedText.GetComponentInChildren<Text>().enabled = true;
        StartCoroutine(pauseAllActions(2f));
    }

    public IEnumerator pauseAllActions(float pauseFor)
    {
        
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + pauseFor;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        // audioManager.GetComponent<audioManagement>().audioS.clip = null;
        resetPlayer();
        
        

    }

    public void tartSeen(GameObject tart)
    {
        transform.position = tart.transform.position;
        seenTart = tart;
        TartinRange = true;
        gameObject.GetComponent<jennaEnemyPatrol>().patrolling = false;
        Invoke("eatTart", 3f);
    }
    public void eatTart()
    {
        //make munchin sounds
        Destroy(seenTart);
        TartinRange = false;
        gameObject.GetComponent<jennaEnemyPatrol>().patrolling = true;

    }

    

}
