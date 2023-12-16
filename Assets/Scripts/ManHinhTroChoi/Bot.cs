using CodeMonkey;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class Bot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ManHinhTroChoi mhtt;
    Vector3 popup = new Vector3(400.0f, -20.0f, 0.0f);
    public float delay = 2;
    float timer;
    int[] piles = { 0, 0, 0, 0, 0};
    int row, sticks;
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            wait();
            timer -= delay;
        }

    }

    private void FixedUpdate()
    {
        
    }

    public void nuocDi()
    {
        getPiles(mhtt.rowList);
        //getPiles(mhtt.getsticks(1), mhtt.getsticks(2), mhtt.getsticks(3), mhtt.getsticks(4), mhtt.getsticks(5));
        
        inPilies();
        (row, sticks) = FindBestMove(piles);
        
        
        Debug.Log("BOT chon hang "+(row +1)+ " va lay "+sticks+".");
        piles[row] -= sticks;
        mhtt.BotChoose(row, sticks);
        
       
        /*int x = mhtt.Bomb.GetComponent<Bomb>().timeRemaining;
        int y = mhtt.maxTurn + 2;
        int m;
        if (x > y)
        {
            if(x % y == 0)
            {
                m = 1;
            }
            else
            {
                m = x % y;
                if(m > mhtt.maxTurn)
                    m = m % mhtt.maxTurn;
            }
            
        }
        else
        {
            m = x - 1;  
        }*/

        

    }
    private void wait()
    {
        

        if (mhtt.getLuotDi() == 2)
        {
            
            // mhtt.checkWin1((nuocDi()));
            nuocDi();
            
        }
    }
    void Delay(float timer, int delay)
    {
        while(timer < delay)
        {
            timer += Time.deltaTime;
        }
        timer = 0;
        
    }

    int NimSum(int[] piles)
    {
        
        int result = 0;
        foreach (int pile in piles)
        {
            result ^= pile;
        }
        return result;
    }

    (int row, int stick) FindBestMove(int[] piles)
    {
        int nimValue = NimSum(piles);
        int sticksToRemove = 0;
        int row = -1;
        if (nimValue == 0)
        {
            // Khong co nuoc di tot neu nim_sum bang 0
            // khi do chon ngau nhien
             System.Random random1 = new System.Random();

            bool lap=true;
            while (lap)
            {
                row = random1.Next(0, mhtt.numRows);
                sticksToRemove = random1.Next(0, piles[row] + 1);
                
                    if (mhtt.rowList[row-1].Count >= sticksToRemove)
                    {
                        lap = false;
                    }
               
            }
            
            
            return (row, sticksToRemove);
            //return (-1, -1);
        }

        for (int i = 0; i < mhtt.numRows; i++)
        {
            int xorValue = nimValue ^ piles[i];
            if (xorValue < piles[i])
            {
                sticksToRemove = piles[i] - xorValue;
                return (i, sticksToRemove);
            }
        }

        // Neu khong tim thay nuoc di tot, chon mot nuoc di ngau nhien
        bool lap2 = true;
        while (lap2)
        {
            System.Random random = new System.Random();
          
           
            row = random.Next(1, mhtt.numRows);
            sticksToRemove = random.Next(1, piles[row] + 1);

            if (mhtt.rowList[row - 1].Count >= sticksToRemove)
            {
                lap2 = false;
            }

        }
        
        return (row, sticksToRemove);
    }

    public void getPiles(List<GameObject>[] rowList)
    {
        //List<GameObject> sticks1, List<GameObject> sticks2, List<GameObject> sticks3, List<GameObject> sticks4, List<GameObject> sticks5
        /*piles[0] = sticks1.Count;
        piles[1] = sticks2.Count;
        piles[2] = sticks3.Count;
        piles[3] = sticks4.Count;
        piles[4] = sticks5.Count;*/
        for (int i = 1;i <= mhtt.numRows;i++)
        {
           piles[i-1] = rowList[i].Count;
            
        }
        
        

    }

    private void inPilies()
    {
        for (int i = 0; i < mhtt.numRows; i++)
        {
            Debug.Log("Pile["+i+"]:" + piles[i]);
        }
        
    }
        
    
}
