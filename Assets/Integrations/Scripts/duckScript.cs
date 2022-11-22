using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duckScript : MonoBehaviour
{
   public void closeDuck(GameObject duckStuff)
    {
        duckStuff.SetActive(false);
    }
    public void openDuck(GameObject duckStuff)
    {
        duckStuff.SetActive(true);
    }
}
