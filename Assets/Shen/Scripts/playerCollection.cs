using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollection : MonoBehaviour
{
    public Transform collectionPoint;
    public float collectionRange = 1f;
    public LayerMask collectItemLayer;
    public bool itemInRange;

    public Text collectedItemText;
    public Text pickPocketedText;
    int numItemsCollected = 0;
    int numItemsPickPocketed = 0;

    public GameObject[] emeralds;

    public GameObject pickUpText;
    public GameObject pickPocketText;

    public LayerMask[] collectiblesLayers;

    // Start is called before the first frame update
    void Start()
    {
        
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
                if(collectibleItem.gameObject.tag == "clue")
                {
                    numItemsCollected++;
                    collectedItemText.text = "Emeralds collected: " + numItemsCollected.ToString() + "/3";
                    // emeralds[emeralds.Length] = collectibleItem.gameObject;
                    collectibleItem.gameObject.SetActive(false);
                }
                else if(collectibleItem.gameObject.tag == "pickPocketTag")
                {
                    numItemsPickPocketed++;
                    pickPocketedText.text = "Items Pickpocketed: " + numItemsPickPocketed.ToString();
                    collectibleItem.gameObject.tag = "Untagged";
                    //change tag of enemy to cant be pickpocketed
                    //Say this guard cant be pickpocketed anymore

                }
                
            }
        }

        if (itemInRange)
        {
            Collider2D[] itemTags = Physics2D.OverlapCircleAll(collectionPoint.position, collectionRange, collectItemLayer);
            foreach(Collider2D tag in itemTags)
            {
                if(tag.gameObject.tag == "clue")
                {
                    pickUpText.SetActive(true);
                }else if(tag.gameObject.tag == "pickPocketTag")
                {
                    pickPocketText.SetActive(true);
                }
            }

            
        }
        else
        {
            pickUpText.SetActive(false);
            pickPocketText.SetActive(false);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (collectionPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(collectionPoint.position, collectionRange);
    }

    public void resetEmeralds()
    {
        numItemsCollected = 0;
        collectedItemText.text = "Emeralds collected: " + numItemsCollected.ToString() + "/3";
        foreach(GameObject item in emeralds)
        {
            item.gameObject.SetActive(true);
        }
        
    }

}
