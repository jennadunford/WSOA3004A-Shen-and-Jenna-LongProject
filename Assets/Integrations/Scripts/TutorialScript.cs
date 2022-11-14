using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public GameObject InventoryHandlerGlobalT;
    // Start is called before the first frame update
    void Start()
    {
        InventoryHandlerGlobalT = GameObject.Find("GlobalInventoryManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.tag == "exitTutLevel")
        {
            Debug.Log("in trigger");
            for(int i = 0; i < InventoryHandlerGlobalT.GetComponent<inventoryHandler>().inventoryItems.Count; i++)
            {
                if(InventoryHandlerGlobalT.GetComponent<inventoryHandler>().inventoryItems[i].itemName == "Tutorial Item")
                {
                    Debug.Log("Inside the if statement");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
}
