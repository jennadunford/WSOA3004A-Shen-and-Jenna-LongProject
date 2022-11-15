using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransitionTesting : MonoBehaviour
{
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("changed scene forwards");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("changed scene backwards");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
