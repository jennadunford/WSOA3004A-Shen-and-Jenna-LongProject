using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryHandler : MonoBehaviour
{
    public Sprite[] itemImages;
   // public List<itemClass> inventoryItems;
   // public List<itemClass> allItems;
    public Text[] inventorySlotNames;
    public Image[] inventoryImages;
    public Text inventoryDescription;
    public int numInvItems = 0;
    List<itemClass> inventoryItems = new List<itemClass>();
    List<itemClass> allItems = new List<itemClass>();
    List<GameObject> itemsCollected = new List<GameObject>();


    private void Awake()
    {
        
      
        
        //creating all the items in the game
        itemClass item0 = new itemClass();
        item0.itemName = "Item in tutorial Level";
        item0.itemDescription = "I am the item that is obtained in the tutorial level";
        item0.usable = false;
        item0.sceneNumber = 1;
        item0.itemImage = itemImages[0];
        item0.gameObjectName = "tutorialItem";
        item0.pickPocketed = false;
        allItems.Add(item0);
       // Debug.Log("Added an item to all items, the length is: " + allItems.Count);

        itemClass item1 = new itemClass();
        item1.itemName = "First item in level 1";
        item1.itemDescription = "I am the first item to be collected in the first level";
        item1.usable = false;
        item1.sceneNumber = 1;
        item1.itemImage = itemImages[1];
        item1.gameObjectName = "item1";
        item1.pickPocketed = false;
        allItems.Add(item1);
        //Debug.Log("Added an item to all items, the length is: " + allItems.Count);

        itemClass item2 = new itemClass();
        item2.itemName = "Second Item in Level 1";
        item2.itemDescription = "I am the second item to be collected in the first level";
        item2.usable = false;
        item2.sceneNumber = 1;
        item2.itemImage = itemImages[2];
        item2.gameObjectName = "item2";
        item2.pickPocketed = false;
        allItems.Add(item2);
        // Debug.Log("Added an item to all items, the length is: " + allItems.Count);

        itemClass pItem1 = new itemClass();
        pItem1.itemName = "First pickpocketed Item";
        pItem1.itemDescription = "I am the first item pickpocketed from a guard!";
        pItem1.usable = false;
        pItem1.sceneNumber = 1;
        pItem1.itemImage = itemImages[3];
        pItem1.gameObjectName = "pickPocketPoint1";
        pItem1.pickPocketed = true;
        allItems.Add(pItem1);
         
   
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        /*
       DontDestroyOnLoad(this.gameObject);

       

        //creating all the items in the game
        itemClass item0 = new itemClass();
        item0.itemName = "Item in tutorial Level";
        item0.itemDescription = "I am the item that is obtained in the tutorial level";
        item0.usable = false;
        item0.sceneNumber = 1;
        item0.itemImage = itemImages[0];
        item0.gameObjectName = "tutorialItem";
        allItems.Add(item0);
        Debug.Log("Added an item to all items, the length is: " + allItems.Count);

        itemClass item1 = new itemClass();
        item1.itemName = "First item in level 1";
        item1.itemDescription = "I am the first item to be collected in the first level";
        item1.usable = false;
        item1.sceneNumber = 1;
        item1.itemImage = itemImages[1];
        item1.gameObjectName = "item1";
        allItems.Add(item1);
        Debug.Log("Added an item to all items, the length is: " + allItems.Count);

        itemClass item2 = new itemClass();
        item2.itemName = "Second Item in Level 1";
        item2.itemDescription = "I am the second item to be collected in the first level";
        item2.usable = false;
        item2.sceneNumber = 1;
        item2.itemImage = itemImages[2];
        item2.gameObjectName = "item2";
        allItems.Add(item2);
        Debug.Log("Added an item to all items, the length is: " + allItems.Count);
       */
    }

    // Update is called once per frame


    public void showDescription(string name)
    {
        int indexVal = int.Parse(name);
        if(indexVal <inventoryItems.Count)
        {
            inventoryDescription.text = inventoryItems[indexVal].getDescription();
        }
        else
        {
            inventoryDescription.text = "There is no item in this slot.";
        }
        
    }

    public void addToInventory(string name, GameObject item)
    {
        //Debug.Log("pls add " + name + " to inventory");
        //Debug.Log("Length of item list: " + allItems.Count);
       for(int i = 0; i < allItems.Count; i++)
        {
            //Debug.Log(allItems[i].getGameObjectName());
            if(allItems[i].getGameObjectName() == name)
            {
               // Debug.Log("We have found " + allItems[i].getGameObjectName());
                inventoryItems.Add(allItems[i]);
                itemsCollected.Add(item);
               updateInventory();
                break;
            }
        }
    }

    public void updateInventory()
    {
        inventoryDescription.text = "";
        //clear everything that was there before
        for (int i = 0; i < inventorySlotNames.Length; i++)
        {
            inventorySlotNames[i].text = "";
           
        }
        for(int i = 0; i < inventoryImages.Length; i++)
        {
            inventoryImages[i].sprite = null;
            inventoryImages[i].gameObject.SetActive(false);
        }
        //update with new info
        for (int i = 0; i< inventoryItems.Count; i++)
        {
            inventorySlotNames[i].text = inventoryItems[i].getName();
            inventoryImages[i].sprite = itemImages[i];
            inventoryImages[i].gameObject.SetActive(true);
        }
    }

    public void loseItemsFromScene(int sceneNum)
    {
       // Debug.Log("Number of inventory items currently: " + inventoryItems.Count);
        for(int i = inventoryItems.Count-1; i >= 0; i--)
        {
            if(inventoryItems[i].sceneNumber == sceneNum)
            {
                //Debug.Log("Removed " + inventoryItems[i].itemName + " from Inventory");
                for(int j = 0; j < itemsCollected.Count; j++)
                {
                    if(itemsCollected[j].name == inventoryItems[i].gameObjectName)
                    {
                        if (inventoryItems[i].pickPocketed)
                        {
                            itemsCollected[j].tag = "pickPocketTag";
                        }
                        else
                        {
                            itemsCollected[j].SetActive(true);
                        }
                        itemsCollected.Remove(itemsCollected[j]);
                        break;
                    }
                }
                inventoryItems.Remove(inventoryItems[i]);                           
            }
        }


        //need to set all lost items to active again



       // Debug.Log("Inventory items after losing" + inventoryItems.Count);
        updateInventory();

    }
}

public class itemClass
{
    public string itemName;
    public string itemDescription;
    public bool usable;
    public int sceneNumber;
    public Sprite itemImage;
    public string gameObjectName;
    public bool pickPocketed;

  public string getDescription()
    {
        return itemDescription;
    }

    public string getName()
    {
        return itemName;
    }

    public string getGameObjectName()
    {
        return gameObjectName;
    }
}
