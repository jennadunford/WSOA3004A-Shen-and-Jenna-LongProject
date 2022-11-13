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

    private void Awake()
    {
        
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
   
    }

    void Start()
    {
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
    void Update()
    {
        
    }

    public void showDescription(string name)
    {
        int indexVal = int.Parse(name);
        inventoryDescription.text = inventoryItems[indexVal].getDescription();
    }

    public void addToInventory(string name)
    {
        Debug.Log("pls add " + name + " to inventory");
        Debug.Log("Length of item list: " + allItems.Count);
       for(int i = 0; i <= allItems.Count; i++)
        {
            Debug.Log(allItems[i].getGameObjectName());
            if(allItems[i].getGameObjectName() == name)
            {
                Debug.Log("We have found " + allItems[i].getGameObjectName());
                inventoryItems.Add(allItems[i]);
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
}

public class itemClass
{
    public string itemName;
    public string itemDescription;
    public bool usable;
    public int sceneNumber;
    public Sprite itemImage;
    public string gameObjectName;

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
