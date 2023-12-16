using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public string SoNguoi;
    public int maxTurn;
    //public int timeRemaining;
    public int  LuotDi;
    public string p1;
    public string p2;

    public int rows;

    public int[] stick;
    /*public int sticks1;
    public int sticks2;
    public int sticks3;
    public int sticks4;
    public int sticks5;*/



    public PlayerData (ManHinhTroChoi mhtc)
    {
       /* maxTurn = mhtc.maxTurn ;*/
        SoNguoi = mhtc.SoNguoi;
        LuotDi = mhtc.LuotDi;
        p1 = mhtc.p1;
        p2 = mhtc.p2;
        /*timeRemaining = mhtc.timeRemaining;*/
        rows = mhtc.numRows;
        stick = new int[rows + 1];
        for(int i = 1; i <= rows; i++)
        {
            stick[i] = mhtc.getsticks(i).Count;
        }
       /* sticks1 = mhtc.getsticks(1).Count;
        sticks2 = mhtc.getsticks(2).Count;
        sticks3 = mhtc.getsticks(3).Count;
        sticks4 = mhtc.getsticks(4).Count;
        sticks5 = mhtc.getsticks(5).Count;*/

    }
}
