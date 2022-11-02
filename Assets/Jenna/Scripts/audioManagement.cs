using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagement : MonoBehaviour
{

    public AudioClip[] sounds;
    public AudioSource audioS;
    // Start is called before the first frame update
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void playerCaught()
    {
        audioS.volume = 0.125f;
        audioS.PlayOneShot(sounds[0]);
    }
}
