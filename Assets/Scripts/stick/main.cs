using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    List<GameObject> sticks1;
    List<GameObject> sticks2;
    List<GameObject> sticks3;
    List<GameObject> selectedList;
    int[,] matran = new int[3, 15];
    public GameObject stickPrefab;

    public Button submit;


    // Start is called before the first frame update
    void Start()
    {
        this.sticks1 = new List<GameObject>();
        this.sticks2 = new List<GameObject>();
        this.sticks3 = new List<GameObject>();
        this.selectedList = new List<GameObject>();

        init();
    }

    // Update is called once per frame
    void Update()
    {
        checkWin();
        checkSubmit();
    }
    void init()
    {
        int n = 3;
        int[] m = { 1, 3, 5, 7, 9, 11 };

        initmatran(n, 15);
        
        System.Random rnd = new System.Random();
        int k = rnd.Next(0,2);
        Debug.Log(k);
        float x = -30.0f;
        float y = 50.0f;
        Vector2 vector2 = new Vector2(x, y);

        for (int i = 1; i <= n; i++)
        {

            for (int j = 1; j <= m[k]; j++)
            {

                GameObject stick = Instantiate(this.stickPrefab);
                stick.name = "CoinPrefab #" + i + "." + j;
                stick.transform.position = vector2;
                vector2.x += 10;
                //this.sticks.Add(stick);
                addStick(i, stick);
                stick.GetComponent<Button>().interactable = false;
                matran[i - 1, j - 1] = 1;
                Debug.Log(i + "," + j);

            }
            
            k+= rnd.Next(1, 3);
            vector2.x = x;
            vector2.y -= 20;
        }



    }
    void checkWin()
    {
        if (sticks1.Count == 0 && sticks2.Count == 0 & sticks3.Count == 0)
            Debug.Log("WINNNNN");
    }

    void initmatran(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {

            for (int j = 0; j < m; j++)
            {
                matran[i, j] = 0;
            }
        }
    }
    void addStick(int i, GameObject stick)
    {
        if (i == 1)
        {
            this.sticks1.Add(stick);
        }
        if (i == 2)
        {
            this.sticks2.Add(stick);

        }
        if (i == 3)
        {
            this.sticks3.Add(stick);
        }
    }

    public void removeStick()
    {

        foreach (var stick in sticks1.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                sticks1.Remove(stick);

            }

        }
        Debug.Log("s1:" + sticks1.Count);
        foreach (var stick in sticks2.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                sticks2.Remove(stick);

            }

        }
        Debug.Log("s2:" + sticks2.Count);
        foreach (var stick in sticks3.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                sticks3.Remove(stick);

            }

        }
        Debug.Log("s3:" + sticks3.Count);
        Unlock();

    }

    public void SelectSticks1()
    {
        selectedList = sticks1;
        lockList(sticks1);
        Debug.Log("khoa 2 3");
    }

    public void SelectSticks2()
    {
        selectedList = sticks2;
        lockList(sticks2);
        Debug.Log("khoa 1 3");
    }

    public void SelectSticks3()
    {
        selectedList = sticks3;
        lockList(sticks3);
        Debug.Log("khoa 1 2");
    }

    private void lockList(List<GameObject> listToEnable)
    {
        foreach (List<GameObject> list in new List<List<GameObject>> { sticks1, sticks2, sticks3 })
        {
            if (list != listToEnable)
            {
                foreach (GameObject obj in list)
                {
                    obj.GetComponent<Button>().interactable = false;
                }
            }
        }

        foreach (GameObject obj in listToEnable)
        {

            obj.GetComponent<Button>().interactable = true;
        }
    }

    public void Unlock()
    {
        List<List<GameObject>> allLists = new List<List<GameObject>> { sticks1, sticks2, sticks3 };

        foreach (List<GameObject> list in allLists)
        {
            foreach (GameObject obj in list)
            {

                obj.SetActive(true);
                obj.GetComponent<Button>().interactable = false;


            }
        }

    }

    void checkSubmit()
    {
        foreach (var stick in sticks1.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                submit.interactable = true;

            }

        }
        
        foreach (var stick in sticks2.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                submit.interactable = true;

            }

        }
        
        foreach (var stick in sticks3.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                submit.interactable = true;

            }

        }
        
        
    }

}
