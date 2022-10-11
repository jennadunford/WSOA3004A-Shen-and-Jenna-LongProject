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
    int numItemsCollected = 0;

    public GameObject[] emeralds;

    public GameObject pickUpText;

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
                numItemsCollected++;
                collectedItemText.text = "Emeralds collected: " + numItemsCollected.ToString();
               // emeralds[emeralds.Length] = collectibleItem.gameObject;
                collectibleItem.gameObject.SetActive(false);
            }
        }

        if (itemInRange)
        {
            pickUpText.SetActive(true);
        }
        else
        {
            pickUpText.SetActive(false);
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
        collectedItemText.text = "Emeralds collected: " + numItemsCollected.ToString();
        foreach(GameObject item in emeralds)
        {
            item.gameObject.SetActive(true);
        }
        
    }

}
