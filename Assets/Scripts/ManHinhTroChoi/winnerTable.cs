using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class winnerTable : MonoBehaviour
{
    private TextMeshProUGUI Winner;

    // Start is called before the first frame update
    private void Awake()
    {
        Winner = transform.Find("Winner").GetComponent<TextMeshProUGUI>();

        gameObject.SetActive(false);
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void setText(string titleString)
    {
        Winner.text = titleString;
    }
}
