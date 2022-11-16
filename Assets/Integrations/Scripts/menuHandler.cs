using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuHandler : MonoBehaviour
{
    public GameObject instructions;
    public GameObject mainButtons;
    public GameObject returnMain;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInstructions()
    {
        instructions.SetActive(true);
        mainButtons.SetActive(false);
        returnMain.SetActive(true);
    }

    public void showCredits()
    {
        credits.SetActive(true);
        mainButtons.SetActive(false);
        returnMain.SetActive(true);
    }

    public void returnToMain()
    {
        mainButtons.SetActive(true);
        credits.SetActive(false);
        instructions.SetActive(false);
        returnMain.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
