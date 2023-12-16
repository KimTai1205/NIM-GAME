using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClickController : MonoBehaviour
{
    public AudioSource audioBtn;
    public AudioSource audioWin;
    public void playButton()
    {
        audioBtn.Play();
    }

    public void playWin()
    {
        audioWin.Play();
    }

}
