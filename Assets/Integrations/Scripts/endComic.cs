using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endComic : MonoBehaviour
{
    public Sprite[] comicImages;
    public string[] comicText = { "Oh! Hello there! Are you the one who stole my precious emerald?!", "No, emperor! It was your dog!" + '\n' + "This most precious baby? No!" + '\n' + "But I found all this evidence and...", "BLEH!" + '\n' + "...", "Oh! So it was you all along! I am sorry for the misunderstanding my dear boy...", "That's okay! Now I can finally enjoy the magic of this tower!" };

    public Text storyText;
    public Image storyImage;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        storyText.text = comicText[counter];
        storyImage.sprite = comicImages[counter];
    }

 
    public void nextPanelEnd()
    {
        counter++;
        if (counter >= comicImages.Length)
        {
            counter = 0;
        }
        storyImage.sprite = comicImages[counter];
        storyText.text = comicText[counter];
    }

    public void close()
    {
        Application.Quit();
    }
}
