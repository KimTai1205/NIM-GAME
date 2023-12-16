using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoryTable : MonoBehaviour
{
    private TextMeshProUGUI p1;
    private TextMeshProUGUI p2;
    // Start is called before the first frame update



    // Start is called before the first frame update
    private void Awake()
    {
        p1 = transform.Find("p1").GetComponent<TextMeshProUGUI>();
        p2 = transform.Find("p2").GetComponent<TextMeshProUGUI>();


    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setText(int luotdi,string titleString)
    {
        if (luotdi == 1)
        {
            p1.text = p1.text + " , " + titleString;
        }
        else
        {
            p2.text = p2.text + " , " + titleString;
        }
        
    }

    public string getP1()
    {
        return p1.text;
    }
    public string getP2()
    {
        return p2.text;
    }

    public void setLoad(string pl1, string pl2)
    {
        p1.text=pl1;
        p2.text=pl2;
    }
}
