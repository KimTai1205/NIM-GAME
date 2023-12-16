using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveTable : MonoBehaviour
{
    public GameObject tb;
    public void show()
    {
        tb.SetActive(true);
    }

    public void hide()
    {
        tb.SetActive(false);
    }
}
