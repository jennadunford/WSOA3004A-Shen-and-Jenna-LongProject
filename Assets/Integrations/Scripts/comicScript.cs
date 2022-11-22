using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class comicScript : MonoBehaviour
{
    public Sprite[] comicImages;
    public string[] comicText = { "Welcome... to the magical, floating tower.", "Finally! I made it... wow... look at this place!", "Oh! Hello there puppy.","...","BLEH!" + '\n' + "Hey! What have you got there?","This looks like an emerald... where did you get this?","HEY YOU OVER THERE! HE'S THE ONE WHO STOLE THE EMPEROR'S EMERALD!","Hey, puppy! Come back here!" };
    public Text storyText;
    public Image storyImage;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        storyImage.sprite = comicImages[counter];
        storyText.text = comicText[counter];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextPanel()
    {
        counter++;
        if(counter>= comicImages.Length)
        {
            counter = 0;
        }
        storyImage.sprite = comicImages[counter];
        storyText.text = comicText[counter];
    }

    public void toGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
