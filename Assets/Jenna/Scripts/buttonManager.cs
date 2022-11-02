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
        Time.timeScale = 0;
        inventoryUI.SetActive(true);
    }
    public void exitInventory()
    {
        Time.timeScale = 1;
        inventoryUI.SetActive(false);
    }

    public void startGame()
    {
        StartCoroutine(gameObject.GetComponent<sceneFadeManager>().FadeAndLoadScene(sceneFadeManager.FadeDirection.Out, 1));
        SceneManager.LoadScene(1);
    }


}
