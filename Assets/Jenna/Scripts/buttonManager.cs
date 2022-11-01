using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
    public GameObject inventoryUI;
 public void exitGame()
    {
        Application.Quit();
    }

    public void openInventory()
    {
        inventoryUI.SetActive(true);
    }
    public void exitInventory()
    {
        inventoryUI.SetActive(false);
    }


}
