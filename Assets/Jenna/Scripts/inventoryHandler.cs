using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inventoryHandler : MonoBehaviour
{
    public Sprite[] itemImages;
   // public List<itemClass> inventoryItems;
   // public List<itemClass> allItems;
    public Text[] inventorySlotNames;
    public Image[] inventoryImages;
    public Text inventoryDescription;
    public int numInvItems = 0;
    public List<itemClass> inventoryItems = new List<itemClass>();
    List<itemClass> allItems = new List<itemClass>();
   public List<GameObject> itemsCollected = new List<GameObject>();


    private void Awake()
    {
              
        //creating all the items in the game
        itemClass itemDogTag = new itemClass();
        itemDogTag.itemName = "Dog Tag";
        itemDogTag.itemDescription = "A tag for a dogs' collar, it reads: The most precious baby boy. Please return to Tower Palace.";
        itemDogTag.usable = false;
        itemDogTag.sceneNumber = 0;
        itemDogTag.itemImage = itemImages[0];
        itemDogTag.gameObjectName = "dogTag";
        itemDogTag.pickPocketed = false;
        itemDogTag.counted = false;
        allItems.Add(itemDogTag);

        itemClass itemSchematic = new itemClass();
        itemSchematic.itemName = "Boiler Room Schematic";
        itemSchematic.itemDescription = "A schematic of the tower boiler room, it is covered in paw prints.";
        itemSchematic.usable = false;
        itemSchematic.sceneNumber = 1;
        itemSchematic.itemImage = itemImages[1];
        itemSchematic.pickPocketed = false;
        itemSchematic.counted = false;
        allItems.Add(itemSchematic);

        itemClass wheelKey = new itemClass();
        wheelKey.itemName = "";




    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame

    private void Update()
    {
       
    }
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
        for(int i = 0; i < inventoryImages.Length-1; i++)
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
    public bool counted;
    public int counter = 0;
    public int maxCount;

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
