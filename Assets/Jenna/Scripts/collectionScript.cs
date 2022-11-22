using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class collectionScript : MonoBehaviour
{
    public Transform collectionPoint;
    public float collectionRange = 1f;
    public LayerMask collectItemLayer;
    public bool itemInRange;

    // public GameObject screenCanvas;
    public GameObject pickUpTextHolder;
    public GameObject pickPocketTextHolder;

    public GameObject pickUpText;
    public GameObject pickPocketText;
    public GameObject tartHolder;
    public GameObject keyTextHolder;

    public LayerMask[] collectiblesLayers;

    public GameObject InventoryHandlerGlobal;

    private GameObject temp;

    public GameObject audioManager;


    // Start is called before the first frame update


    void Start()
    {
        audioManager = GameObject.Find("Audio Manager");
        keyTextHolder = GameObject.Find("keyText");
        pickUpTextHolder = GameObject.Find("pickUpText");
        pickPocketTextHolder = GameObject.Find("pickPocketText");
        tartHolder = GameObject.Find("tartText");
        InventoryHandlerGlobal = GameObject.Find("GlobalInventoryManager");
        InventoryHandlerGlobal.GetComponent<inventoryHandler>().itemsCollected.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        itemInRange = Physics2D.OverlapCircle(collectionPoint.position, collectionRange, collectItemLayer);

        if (itemInRange && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 0")))
        {
            Collider2D[] items = Physics2D.OverlapCircleAll(collectionPoint.position, collectionRange, collectItemLayer);

            foreach (Collider2D collectibleItem in items)
            {
                if (collectibleItem.gameObject.tag == "clue")
                {
                    //Debug.Log(collectibleItem.gameObject.name);
                    InventoryHandlerGlobal.GetComponent<inventoryHandler>().addToInventory(collectibleItem.gameObject.name, collectibleItem.gameObject);
               

                    collectibleItem.gameObject.SetActive(false);
                }
                else if (collectibleItem.gameObject.tag == "pickPocketTag")
                {

                    InventoryHandlerGlobal.GetComponent<inventoryHandler>().addToInventory(collectibleItem.gameObject.name, collectibleItem.gameObject);
                    collectibleItem.gameObject.tag = "Untagged";
                    collectibleItem.gameObject.GetComponent<AudioSource>().enabled = false;
                    //
                    audioManager.GetComponent<audioManagement>().playerPickPocket();
                    pickPocketTextHolder.GetComponent<Image>().enabled = false;
                    pickPocketTextHolder.GetComponentInChildren<Text>().enabled = false;

                }
                else if(collectibleItem.gameObject.tag == "tartHolder")
                {
                    InventoryHandlerGlobal.GetComponent<inventoryHandler>().increaseTarts();
                }
                else if(collectibleItem.gameObject.tag == "Wheel")
                {
                    if (InventoryHandlerGlobal.GetComponent<inventoryHandler>().hasItem("Steam Wheel Key"))
                    {
                        Debug.Log("Can turn wheel");
                        GameObject steam = GameObject.Find("steamHolder");
                        steam.SetActive(false);
                        temp = steam;
                        Invoke("turnBackOn", 5f);
                    }
                }
                else if(collectibleItem.gameObject.tag == "Lantern")
                {
                    if (InventoryHandlerGlobal.GetComponent<inventoryHandler>().hasItem("Box of Matches"))
                    {
                        Debug.Log("Turn lights on");
                        GameObject globalLight = GameObject.Find("Light2D");
                        globalLight.GetComponent<Light2D>().intensity = 0.91f;
                        GameObject A1Light = GameObject.Find("LitArea1");
                        GameObject A2Light = GameObject.Find("LitArea2");
                        GameObject A3Light = GameObject.Find("LitArea3");
                        Debug.Log(A1Light.name);
                        A1Light.SetActive(false);
                        A2Light.SetActive(false);
                        A3Light.SetActive(false);

                    }
                }
                else if(collectibleItem.gameObject.tag == "tart")
                {
                    InventoryHandlerGlobal.GetComponent<inventoryHandler>().incrementTarts(collectibleItem.gameObject);
                }

            }
        }

        if (itemInRange)
        {
            Collider2D[] itemTags = Physics2D.OverlapCircleAll(collectionPoint.position, collectionRange, collectItemLayer);
            foreach (Collider2D tag in itemTags)
            {
                if (tag.gameObject.tag == "clue")
                {
                    // pickUpText.SetActive(true);
                    // pickUpImage.enabled = true;
                    // pickUpT.enabled = true;
                    pickUpTextHolder.GetComponent<Image>().enabled = true;
                    pickUpTextHolder.GetComponentInChildren<Text>().enabled = true;
                }
                else if (tag.gameObject.tag == "pickPocketTag")
                {
                    //pickPocketText.SetActive(true);
                    //pickPocketImage.enabled = true;
                   // pickPocketT.enabled = true;
                    pickPocketTextHolder.GetComponent<Image>().enabled = true;
                    pickPocketTextHolder.GetComponentInChildren<Text>().enabled = true;
                }
                else if(tag.gameObject.tag == "tartHolder")
                {
                    tartHolder.GetComponent<Image>().enabled = true;
                    tartHolder.GetComponentInChildren<Text>().enabled = true;
                }
                else if(tag.gameObject.tag == "Wheel")
                {
                    if (InventoryHandlerGlobal.GetComponent<inventoryHandler>().hasItem("Steam Wheel Key"))
                    {
                        keyTextHolder.GetComponent<Image>().enabled = true;
                        keyTextHolder.GetComponentInChildren<Text>().text = "Use Key";
                        keyTextHolder.GetComponentInChildren<Text>().enabled = true;
                       // Debug.Log("Has key");
                    }
                   
                    
                }
                else if(tag.gameObject.tag == "Lantern")
                {
                    if(InventoryHandlerGlobal.GetComponent<inventoryHandler>().hasItem("Box of Matches"))
                    {
                        keyTextHolder.GetComponent<Image>().enabled = true;
                        keyTextHolder.GetComponentInChildren<Text>().enabled = true;

                        keyTextHolder.GetComponentInChildren<Text>().text = "Use Matches";
                        //Debug.Log("On master lantern with matches");
                    }
                    else
                    {
                        Debug.Log("By master lantern - no matches");
                    }
                }
                else if(tag.gameObject.tag == "tart")
                {
                    keyTextHolder.GetComponent<Image>().enabled = true;
                    keyTextHolder.GetComponentInChildren<Text>().enabled = true;

                    keyTextHolder.GetComponentInChildren<Text>().text = "Pick Up Tart";
                }
            }


        }
        else
        {
            //pickUpText.SetActive(false);
           // pickUpImage.enabled = false;
           // pickUpT.enabled = false;
            pickUpTextHolder.GetComponent<Image>().enabled = false;
            pickUpTextHolder.GetComponentInChildren<Text>().enabled = false;

            //pickPocketText.SetActive(false);
           // pickPocketImage.enabled = false;
            pickPocketTextHolder.GetComponent<Image>().enabled = false;
            pickPocketTextHolder.GetComponentInChildren<Text>().enabled = false;
            //pickPocketT.enabled = false;
            tartHolder.GetComponent<Image>().enabled = false;
            tartHolder.GetComponentInChildren<Text>().enabled = false;

            keyTextHolder.GetComponent<Image>().enabled = false;
            keyTextHolder.GetComponentInChildren<Text>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 2") && InventoryHandlerGlobal.GetComponent<inventoryHandler>().hasItem("Tower Tarts"))
        {

            InventoryHandlerGlobal.GetComponent<inventoryHandler>().decreaseTarts(transform);

        }

    }

    public void turnBackOn()
    {
        temp.SetActive(true);

    }

    private void OnDrawGizmosSelected()
    {
        if (collectionPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(collectionPoint.position, collectionRange);
    }


  

}
