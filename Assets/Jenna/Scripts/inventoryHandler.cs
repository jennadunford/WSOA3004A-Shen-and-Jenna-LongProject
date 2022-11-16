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
    public GameObject canvas;
    public Text[] inventorySlotNames;
    public Image[] inventoryImages;
    public Text inventoryDescription;
    public int numInvItems = 0;
    public List<itemClass> inventoryItems = new List<itemClass>();
    List<itemClass> allItems = new List<itemClass>();
   public List<GameObject> itemsCollected = new List<GameObject>();
    public GameObject tartHolder;
    public Text tartCount;

    public Text tartInfo;

    public GameObject newTartPrefab;

    public GameObject tutorialLevelGoals;
    public GameObject Level1Goals;
    public GameObject Level2Goals;
    public GameObject Level3Goals;
    public GameObject Level4Goals;


    private void Awake()
    {
        tartInfo.text = "Has not unlocked tarts";
        //creating all the items in the game
        itemClass itemDogTag = new itemClass();
        itemDogTag.itemName = "Dog Tag";
        itemDogTag.itemDescription = "A tag for a dogs' collar, it reads: The most precious baby boy. Please return to Tower Palace.";
        itemDogTag.usable = false;
        itemDogTag.sceneNumber = 1;
        itemDogTag.itemImage = itemImages[0];
        itemDogTag.gameObjectName = "dogTag";
        itemDogTag.pickPocketed = false;
        itemDogTag.counted = false;
        allItems.Add(itemDogTag);

        itemClass itemSchematic = new itemClass();
        itemSchematic.itemName = "Boiler Schematic";
        itemSchematic.itemDescription = "A schematic of the tower boiler room, it is covered in paw prints.";
        itemSchematic.usable = false;
        itemSchematic.sceneNumber = 2;
        itemSchematic.itemImage = itemImages[1];
        itemSchematic.gameObjectName = "itemSchematic";
        itemSchematic.pickPocketed = false;
        itemSchematic.counted = false;
        allItems.Add(itemSchematic);

        itemClass wheelKey = new itemClass();
        wheelKey.itemName = "Steam Wheel Key";
        wheelKey.itemDescription = "A key used in the tower boiler room to allow the use of a steam wheel, which can shut off the flow of steam for a while";
        wheelKey.usable = false;
        wheelKey.sceneNumber = 2;
        wheelKey.itemImage = itemImages[2];
        wheelKey.gameObjectName = "wheelKey";
        wheelKey.pickPocketed = true;
        wheelKey.counted = false;
        allItems.Add(wheelKey);

        itemClass ruinedBook = new itemClass();
        ruinedBook.itemName = "Chewed Up Book";
        ruinedBook.itemDescription = "A book about the history of the tower, it is chewed up and covered in paw prints. It has a green binding.";
        ruinedBook.usable = false;
        ruinedBook.sceneNumber = 3;
        ruinedBook.itemImage = itemImages[3];
        ruinedBook.gameObjectName = "ruinedBook";
        ruinedBook.pickPocketed = false;
        ruinedBook.counted = false;
        allItems.Add(ruinedBook);

        itemClass itemMatches = new itemClass();
        itemMatches.itemName = "Box of Matches";
        itemMatches.itemDescription = "A box of matches from the tower library - can be used to light the Master Lantern.";
        itemMatches.usable = false;
        itemMatches.sceneNumber = 3;
        itemMatches.pickPocketed = true;
        itemMatches.itemImage = itemImages[4];
        itemMatches.gameObjectName = "matches";
        itemMatches.counted = false;
        allItems.Add(itemMatches);

        itemClass towerTarts = new itemClass();
        towerTarts.itemName = "Tower Tarts";
        towerTarts.itemDescription = "A sweet pastry enjoyed by the people of the tower. It is particularly loved by the guards, who will drop everything to eat one of these tasty treats.";
        towerTarts.usable = true;
        towerTarts.sceneNumber = 10;
        towerTarts.pickPocketed = false;
        towerTarts.itemImage = itemImages[5];
        towerTarts.gameObjectName = "towerTarts";
        towerTarts.counted = true;
        towerTarts.maxCount = 5;
        towerTarts.counter = 0;
        allItems.Add(towerTarts);

        itemClass leverChewed = new itemClass();
        leverChewed.itemName = "Chewed Up Lever";
        leverChewed.itemDescription = "A freshly chewed up lever used in the tower dungeon. It had a coat of green paint on it. There must be a spare lever.";
        leverChewed.usable = false;
        leverChewed.sceneNumber = 5;
        leverChewed.pickPocketed = false;
        leverChewed.itemImage = itemImages[6];
        leverChewed.gameObjectName = "leverChewed";
        leverChewed.counted = false;
        allItems.Add(leverChewed);

        itemClass dailyLog = new itemClass();
        dailyLog.itemName = "Daily Log";
        dailyLog.itemDescription = "The daily log from one of the tower guards. It notes that a few minutes ago a dog ran through here with something green in its mouth. The log also notes that it was probably not important or anything.";
        dailyLog.usable = false;
        dailyLog.sceneNumber = 5;
        dailyLog.pickPocketed = true;
        dailyLog.itemImage = itemImages[7];
        dailyLog.gameObjectName = "dailyLog";
        dailyLog.counted = false;
        allItems.Add(dailyLog);

        itemClass emeraldHolder = new itemClass();
        emeraldHolder.itemName = "Glass Casing";
        emeraldHolder.itemDescription = "The glass casing that held the tower's emerald. It is covered in paw prints and dog slobber.";
        emeraldHolder.usable = false;
        emeraldHolder.sceneNumber = 5;
        emeraldHolder.pickPocketed = false;
        emeraldHolder.itemImage = itemImages[8];
        emeraldHolder.gameObjectName = "emeraldHolder";
        emeraldHolder.counted = false;
        allItems.Add(emeraldHolder);


    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        updateInventory();
    }

    private void Update()
    {

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                tutorialLevelGoals.SetActive(true);
                Level1Goals.SetActive(false);
                Level2Goals.SetActive(false);
                Level3Goals.SetActive(false);
                Level4Goals.SetActive(false);
    
                break;
            case 2:
                tutorialLevelGoals.SetActive(false);
                Level1Goals.SetActive(true);
                Level2Goals.SetActive(false);
                Level3Goals.SetActive(false);
                Level4Goals.SetActive(false);

                break;
            case 3:
                tutorialLevelGoals.SetActive(false);
                Level1Goals.SetActive(false);
                Level2Goals.SetActive(true);
                Level3Goals.SetActive(false);
                Level4Goals.SetActive(false);

                break;
            case 4:
                tutorialLevelGoals.SetActive(false);
                Level1Goals.SetActive(false);
                Level2Goals.SetActive(false);
                Level3Goals.SetActive(true);
                Level4Goals.SetActive(false);

                break;
            case 5:
                tutorialLevelGoals.SetActive(false);
                Level1Goals.SetActive(false);
                Level2Goals.SetActive(false);
                Level3Goals.SetActive(false);
                Level4Goals.SetActive(true);

                break;
            case 6:
                canvas.SetActive(false);
                break;
        }
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
       for(int i = 0; i < allItems.Count; i++)
        {        
            if(allItems[i].getGameObjectName() == name)
            {
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
        for (int i = 0; i < inventorySlotNames.Length; i++)
        {
            inventorySlotNames[i].text = "";

        }
        for (int i = 0; i < inventoryImages.Length - 1; i++)
        {
            inventoryImages[i].sprite = null;
            inventoryImages[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventorySlotNames[i].text = inventoryItems[i].getName();
            inventoryImages[i].sprite = inventoryItems[i].itemImage;
            inventoryImages[i].gameObject.SetActive(true);
        }
        if (hasItem("Tower Tarts"))
        {
            tartCount.text = inventoryItems[getInventoryIndex("Tower Tarts")].counter.ToString();
            tartHolder.SetActive(true);
            if (inventoryItems[getInventoryIndex("Tower Tarts")].counter < inventoryItems[getInventoryIndex("Tower Tarts")].maxCount)
            {
                tartInfo.text = "Get Tarts";
            }else if(inventoryItems[getInventoryIndex("Tower Tarts")].counter == inventoryItems[getInventoryIndex("Tower Tarts")].maxCount)
            {
                tartInfo.text = "Tarts are at Max";
            }
        }
        else
        {
            tartHolder.SetActive(false);
            tartInfo.text = "Have not unlocked tarts.";
        }
    }

    public void loseItemsFromScene(int sceneNum)
    {
        for(int i = inventoryItems.Count-1; i >= 0; i--)
        {
            if(inventoryItems[i].sceneNumber == sceneNum)
            {
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
        updateInventory();
    }

    public void incrementTarts(GameObject newTart)
    {
        if(hasItem("Tower Tarts"))
        {
            int tartIndex = getInventoryIndex("Tower Tarts");
            if(inventoryItems[tartIndex].counter < inventoryItems[tartIndex].maxCount)
            {
                inventoryItems[tartIndex].counter++;
                Destroy(newTart);
                updateInventory();
            }
        }
    }

    public void dropTart(Transform tartPos)
    {
        Instantiate(newTartPrefab, tartPos.position, Quaternion.identity);
    }

    public void increaseTarts()
    {
        if (hasItem("Tower Tarts"))
        {
            if(inventoryItems[getInventoryIndex("Tower Tarts")].counter < inventoryItems[getInventoryIndex("Tower Tarts")].getMaxCount())
            {
                inventoryItems[getInventoryIndex("Tower Tarts")].counter = inventoryItems[getInventoryIndex("Tower Tarts")].getMaxCount();
                updateInventory();
            }
            else
            {
                Debug.Log("Tarts already at max");
            }
        }
        else
        {
            Debug.Log("Has not unlocked tower tarts");
        }
        
    }

    public void decreaseTarts(Transform tartPos)
    {
        if(hasItem("Tower Tarts"))
        {
            if(inventoryItems[getInventoryIndex("Tower Tarts")].getCurrentCount() > 0)
            {
                inventoryItems[getInventoryIndex("Tower Tarts")].counter = inventoryItems[getInventoryIndex("Tower Tarts")].counter-1;
                updateInventory();
                dropTart(tartPos);
            }
            else
            {
                updateInventory();
            }
        }
       
    }

    public bool hasItem(string itemName)
    {
        bool output = false;
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if(inventoryItems[i].itemName == itemName)
            {
               output =  true;
                break;
            }
            else
            {
                output = false;
            }
        }

        return output;   
    }

    public int getInventoryIndex(string itemName)
    {
        int output = 0;
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].itemName == itemName)
            {
                output = i;
                break;
            }
        }
        return output;
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
    public int maxCount = 5;

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

    public int getCurrentCount()
    {
        return counter;
    }

    public int getMaxCount()
    {
        return maxCount;
    }
}
