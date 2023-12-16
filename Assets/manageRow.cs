using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageRow : MonoBehaviour
{
    public GameObject mhtt;
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;
    public GameObject r5;

    void Start()
    {
        int n = mhtt.GetComponent<ManHinhTroChoi>().numRows;
        for (int i = 1; i <= n; i++) 
        { 
            activeRow(i);
        }
    }

    // Update is called once per frame
    void activeRow(int i)
    {
        if(i == 1)
            r1.SetActive(true);
        if (i == 2)
            r2.SetActive(true);
        if (i == 3)
            r3.SetActive(true);
        if (i == 4)
            r4.SetActive(true);
        if (i == 5)
            r5.SetActive(true);
    }
}
