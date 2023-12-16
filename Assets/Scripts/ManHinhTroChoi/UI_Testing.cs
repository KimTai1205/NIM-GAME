using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using CodeMonkey;
using System;

public class UI_Testing : MonoBehaviour
{
    [SerializeField] private UI_InputWindow inputWindow;
    Vector3 popup = new Vector3(-100.0f, -20.0f,0.0f);
    [SerializeField] private ManHinhTroChoi mhtt;
    private string textAble = new string("");

  
    private void Start()
    {
        /*Maxturn();

        transform.Find("hide_showBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            inputWindow.Show("Turn Player " + mhtt.LuotDi, "Max Turn: " + mhtt.maxTurn, "", textAble , 1 ,(string inputText) =>
            {
                
                CMDebug.TextPopup("Turn Player " + mhtt.LuotDi + ": " + inputText, popup, 1);
                mhtt.checkWin1(Int16.Parse(inputText));   
            
            });
        };*/

    }
    private void Maxturn()
    {
        /*for (int i = 1; i <= mhtt.maxTurn; i++)
        {
            textAble = textAble + i;

        }*/
    }
    
}
