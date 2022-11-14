using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_Manager : MonoBehaviour
{
    public GameObject singleResponsePrompt;
    public Text singleResponsePromptText;
    public Text singleResponsePromptTitle;
    public Text singleResponsePromptClose;

    public GameObject doubleResponsePrompt;
    public Text TextDoubleRes;
    public Text TitleDoubleRes;
    public Text R1DoubleRes;
    public Text R2DoubleRes;

    public GameObject option1Double;
    public GameObject option2Double;

    public bool responseOpt1 = false;
    public bool responseOpt2 = false;

    /*
    public delegate void option(PointerEventData data);
    public option testOption1;
    public option testOption2;

    public delegate void opt();
    public opt tryThis;*/
    // Start is called before the first frame update
    void Start()
    {
        // option1ToTest(testOption1);
        // option2ToTest(testOption2);
        //tryThis = toTry;
        // testOption2 = option2ToTest;
        showDoubleResponsePrompt("Test", "Here we are testing the two prompts", "Try yes", "or no");
      
    }

    // Update is called once per frame
    void Update()
    {
        if (responseOpt1)
        {
            showSingleResponsePrompt("Nice", "You clicked yes on the previous prompt huh", "yup");
            responseOpt1 = false;
            responseOpt2 = false;
        }else if (responseOpt2)
        {
            showSingleResponsePrompt("Cool", "You clicked no on the previous prompt!", "close");
            responseOpt1 = false;
            responseOpt2 = false;
        }
    }

    public void showSingleResponsePrompt(string Title, string Prompt, string exitString)
    {
        singleResponsePromptText.text = Prompt;
        singleResponsePromptTitle.text = Title;
        singleResponsePromptClose.text = exitString;
        singleResponsePrompt.SetActive(true);

        
    }

    public void showDoubleResponsePrompt(string Title, string Prompt, string exitString1, string exitString2)
    {
        TextDoubleRes.text = Prompt;
        TitleDoubleRes.text = Title;
        R1DoubleRes.text = exitString1;
        R2DoubleRes.text = exitString2;

        doubleResponsePrompt.SetActive(true);

        
    }

    public void closeSingleResponsePrompt()
    {
        singleResponsePrompt.SetActive(false);
    }

    public void clickOpt1()
    {
        responseOpt1 = true;
        responseOpt2 = false;
        Debug.Log("clicked option 1");
        doubleResponsePrompt.SetActive(false);
    }

    public void clickOpt2()
    {
        responseOpt1 = false;
        responseOpt2 = true;
        Debug.Log("clicked option 2");
        doubleResponsePrompt.SetActive(false);
    }


}
