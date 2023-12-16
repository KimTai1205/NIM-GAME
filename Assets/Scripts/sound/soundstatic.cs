using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundstatic : MonoBehaviour
{
    public static AudioSource audioStick;
    // Start is called before the first frame update
    public static void play()
    {
        audioStick.Play();
    }
}