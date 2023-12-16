using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stick : MonoBehaviour
{
    bool selected = false;

    GameObject sound;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool selecte()
    {
        this.selected = true;

        return this.selected;

    }

    public void setSound(GameObject goSound)
    {
        this.sound = goSound;
    }

    public void play()
    {
        this.sound.GetComponent<AudioSource>().Play();
    }
}
