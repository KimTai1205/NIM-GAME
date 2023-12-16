using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSoundController : MonoBehaviour
{
    public AudioSource audiobtn;
    
    public void playButton()
    {
        audiobtn.Play();
    }
}
