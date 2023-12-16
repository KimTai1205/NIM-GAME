using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
///using Unity.PlasticSCM.Editor.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManHinhTroChoi : MonoBehaviour
{
    public string SoNguoi;
    //public int maxTurn;
    //public int timeRemaining;
    //public GameObject Bomb;
    public GameObject Player,Player2,Bot;
    public GameObject turn1,turn2;



    //Timer
    public Slider timerSlider;
    public float sliderTimer;
    bool StopTimer = false;
    public GameObject timecount;


    public int x,LuotDi = 0; // 1 la cua nguoi choi 1, 2 la cua nguoi choi 2 hoac AI
    [SerializeField] private GameObject winnerTable;
    [SerializeField] private GameObject historyTable;
    public string p1, p2;

    //
    //List<List<GameObject>> rows;
    public int numRows;
    List<GameObject> sticks1;
    List<GameObject> sticks2;
    List<GameObject> sticks3;
    List<GameObject> sticks4;
    List<GameObject> sticks5;
    //mang danh sach cac hang
    public List<GameObject>[] rowList;
    //danh sach cac stick da click de refesh
    List<GameObject> selectedList;


    int[,] matran = new int[3, 15];

    

    public GameObject stickPrefab;

    public GameObject soundPrefab;

    public Button submit;


    private void Awake()
    {
         
        // Debug.Log(maxTurn);
        // timeRemaining = rnd.Next(30, 35);
        // Bomb.GetComponent<Bomb>().setTime(timeRemaining);
        //Lay Thong tin choi 1 nguoi choi hay 2 nguoi choi
        

       /* this.sticks1 = new List<GameObject>();
        this.sticks2 = new List<GameObject>();
        this.sticks3 = new List<GameObject>();
        this.sticks4 = new List<GameObject>();
        this.sticks5 = new List<GameObject>();*/

        this.selectedList = new List<GameObject>();

        if (GameObject.FindGameObjectWithTag("SoNguoiChoi") != null)
        {
            GameObject goSN = GameObject.FindGameObjectWithTag("SoNguoiChoi") as GameObject;
            SoNguoi = goSN.GetComponent<SoNguoiChoi>().SoNguoi;
            
            
            if (SoNguoi.Equals("loadgame") )
            {
                LoadPlayer();
                
            }
            else
            {
                init();
            }
        }
        else
        {
            SceneManager.LoadScene("ManhHinhDanhMuc");

            
        }
        Debug.Log(SoNguoi);
        if(SoNguoi.Equals("1nguoi"))
        {
            Bot.SetActive(true);

        }
        if (SoNguoi.Equals("2nguoi"))
        {
            Player2.SetActive(true);
        }


        // init();



    }



    /*public void checkWin1(int timedown)
    {
        historyTable.GetComponent<HistoryTable>().setText(LuotDi, timedown.ToString());
        Bomb.GetComponent<Bomb>().timeDown(timedown);
        timeRemaining = Bomb.GetComponent<Bomb>().timeRemaining;
        if(timeRemaining <= 0)
        {
            Bomb.GetComponent<Bomb>().explode();
            winnerTable.SetActive(true);
            if ( LuotDi == 1)
            {
                if (Bot.GetComponent<Bot>().isActiveAndEnabled)
                {
                    winnerTable.GetComponent<winnerTable>().setText(this.Bot.name + " WIN!!!");
                }
                else
                {
                    winnerTable.GetComponent<winnerTable>().setText(this.Player2.name + " WIN!!!");
                }
                
                
                Debug.Log("Nguoi choi 2 thang");
                
            }
            else
            {
                winnerTable.GetComponent<winnerTable>().setText("Player 1 WIN!!!");
                
                Debug.Log("Nguoi choi 1 thang");
                
            }
            
            return;

        }
        if (LuotDi == 1)
        {
            Player.GetComponent<Player>().setAnim();
        }
        else if(LuotDi == 2)
        {
            if (Bot.GetComponent<Bot>().isActiveAndEnabled)
            {
                Bot.GetComponent<Player>().setAnim();
            }
            else
            {
                Player2.GetComponent<Player>().setAnim();
            }
                
        }
        Bomb.GetComponent<Bomb>().setAnim();
        
        LuotDi = Math.Abs(LuotDi - 3);
        Debug.Log("Luot cua" + LuotDi);
      
        Debug.Log(Bomb.GetComponent<Bomb>().timeRemaining);



    }*/
    bool emptyStick()
    {
        for (int i = 1; i <= numRows; i++)
        {
            if (rowList[i].Count != 0) return false;
        }
        return true;
    }


    void checkWin()
    {
       // if (sticks1.Count == 0 && sticks2.Count == 0 && sticks3.Count == 0 && sticks4.Count == 0 && sticks5.Count == 0)
        if (emptyStick())
        {
            winnerTable.SetActive(true);
            if (LuotDi == 1)
            {
                if (Bot.GetComponent<Bot>().isActiveAndEnabled)
                {
                    winnerTable.GetComponent<winnerTable>().setText(this.Bot.name + " WIN!!!");
                }
                else
                {
                    winnerTable.GetComponent<winnerTable>().setText(this.Player2.name + " WIN!!!");
                }


                Debug.Log("Nguoi choi 2 thang");

            }
            else
            {
                winnerTable.GetComponent<winnerTable>().setText("Player 1 WIN!!!");

                Debug.Log("Nguoi choi 1 thang");

            }
        }
    }
    void Start()
    {
        // Toggle fullscreen
        

        if (LuotDi == 2)
        {
            // bombload();
            turn1.SetActive(false);
            turn2.SetActive(true);
        }
        else
        {
            if (LuotDi == 0 || LuotDi ==1)
            {
                LuotDi = 1;
                turn1.SetActive(true);
                turn2.SetActive(false);
            }
                
        }

        timedown();
    }

    //Timer
    public void timedown()
    {
        stopTimer();
        sliderTimer = 20.0f;
        StopTimer = false;
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;

        

      
      

    }

    void StartTheTimer()
    {

        if (StopTimer == false)
        {
            sliderTimer -= Time.deltaTime;
            timerSlider.value = sliderTimer;
            
            timecount.GetComponent<TextMeshProUGUI>().text = ((int)sliderTimer /1).ToString() + ":" + ((int)((sliderTimer%1)*100)/1).ToString();

        }

       
            

         if (sliderTimer <= 0)
            {
                StopTimer = true;
            timeout();
                    
            }
         
        
    }

    void timeout()
    {
        if (submit.interactable == true)
        {
            submit.GetComponent<Button>().onClick.Invoke();
        }
            
        else
        {
            /*if (rowList[0].Count > 0)
            {
                BotChoose(0, 1);
                return;
            }
            if (sticks2.Count > 0)
            {
                BotChoose(1, 1);
                return;
            }
            if (sticks3.Count > 0)
            {
                BotChoose(2, 1);
                return;
            }
            if (sticks4.Count > 0)
            {
                BotChoose(3, 1);
                return;
            }
            if (sticks5.Count > 0)
            {
                BotChoose(4, 1);
                return;
            }*/
            for(int i = 1; i <= numRows; i++)
            {
                if (rowList[i].Count > 0)
                {
                    BotChoose(i, 1);
                    return;
                }
            }
        }
       
    }

    public void stopTimer()
    {
        StopTimer = true;
    }

    public void continueTimer()
    {
        StopTimer = false;
    }

    void Update()
    {
        checkWin();
        checkSubmit();
        StartTheTimer();

    }
    public void setLuotDi(int x)
    {
        LuotDi = x;
    }
    public int getLuotDi()
    {
        return LuotDi;
    }

    public void SavePlayer()
    {
        p1 = new string(historyTable.GetComponent<HistoryTable>().getP1());
        p2 = new string(historyTable.GetComponent<HistoryTable>().getP2());
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SoNguoi = data.SoNguoi;
        /*maxTurn = data.maxTurn;*/
        /*Bomb.GetComponent<Bomb>().setTime(data.timeRemaining);*/
        LuotDi = data.LuotDi;
        // bang history
        p1 = data.p1;
        p2 = data.p2;
        historyTable.GetComponent<HistoryTable>().setLoad(p1, p2);
        // load stick
        numRows = data.rows;
        
        rowList = new List<GameObject>[numRows + 1];

        for (int i = 1; i <= numRows; i++)
            rowList[i] = new List<GameObject>();
        int k = 0;
        //int[] m = {data.sticks1,data.sticks2,data.sticks3, data.sticks4 , data.sticks5 };
        int[] m = new int[numRows];
        for(int i = 0; i < numRows; i++)
        {
            m[i] = data.stick[i + 1];
        }
        float x = -300.0f;
        float y = 360.0f;
        Vector2 vector2 = new Vector2(x, y);

        GameObject sound = Instantiate(this.soundPrefab);
        sound.name = "SoundPrefab #";

        for (int i = 1; i <= numRows; i++)
        {

            for (int j = 1; j <= m[k]; j++)
            {

                GameObject stick = Instantiate(this.stickPrefab);
                stick.name = "StickPrefab #" + i + "." + j;
                stick.GetComponent<stick>().setSound(sound);
                stick.transform.position = vector2;
                vector2.x += 50;
                //this.sticks.Add(stick);
                addStick(i, stick);
                stick.GetComponent<Button>().interactable = false;
                //matran[i - 1, j - 1] = 1;
                Debug.Log(i + "," + j);

            }
            System.Random rnd = new System.Random();
            k ++;
            vector2.x = x;
            vector2.y -= 145;
        }

    }
    //public void bombload()
   // {
     // Bomb.GetComponent<Bomb>().setAnim();
   // }

    void init()
    {
        int n = 3;
        int[] m = { 1, 3, 5, 7, 9, 11, 13 };

        initmatran(n, 15);
        System.Random rndRow = new System.Random();
        numRows = rndRow.Next(3, 6);
        rowList = new List<GameObject>[numRows + 1];

        for (int i = 1; i <= numRows; i++)
            rowList[i] = new List<GameObject>();

        System.Random rnd = new System.Random();
        
        int k = rnd.Next(0, 2);
        Debug.Log(k);
        float x = -300.0f;
        float y = 360.0f;
        Vector2 vector2 = new Vector2(x, y);

        GameObject sound = Instantiate(this.soundPrefab);
        sound.name = "SoundPrefab #";

        for (int i = 1; i <=numRows; i++)
        {

            for (int j = 1; j <= m[k]; j++)
            {

                GameObject stick = Instantiate(this.stickPrefab);
                stick.name = "StickPrefab #" + i + "." + j;
                stick.GetComponent<stick>().setSound(sound);
                stick.transform.position = vector2;
                vector2.x += 50;
                //this.sticks.Add(stick);
                addStick(i, stick);
                stick.GetComponent<Button>().interactable = false;
                //matran[i - 1, j - 1] = 1;
                Debug.Log(i + "," + j);

            }

            k += rnd.Next(1, 3);
            
            if(k > 6)
                k = 6;
            vector2.x = x;
            vector2.y -= 145;
        }



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
        rowList[i].Add(stick);
        /*if (i == 1)
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
        if (i == 4)
        {
            this.sticks4.Add(stick);
        }
        if (i == 5)
        {
            this.sticks5.Add(stick);
        }*/
    }

    public void removeStick()
    {
        int rowDelete = 0;
        int stickDeleted = 0;
        
        for (int i = 1; i <= numRows; i++)
        {
            foreach (var stick in rowList[i].ToList())
            {
                if (!stick.activeInHierarchy)
                {
                    
                    rowList[i].Remove(stick);
                    
                    rowDelete = i;
                    stickDeleted++;
                    

                }
                
            }
            Debug.Log("s" + i + ":" + rowList[i].Count);
        }
        /*foreach (var stick in sticks1.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                sticks1.Remove(stick);
                rowDelete = 1;
                stickDeleted++;

            }

        }
        Debug.Log("s1:" + sticks1.Count);
        foreach (var stick in sticks2.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                sticks2.Remove(stick);
                rowDelete = 2;
                stickDeleted++;
            }

        }
        Debug.Log("s2:" + sticks2.Count);
        foreach (var stick in sticks3.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                sticks3.Remove(stick);
                rowDelete = 3;
                stickDeleted++;
            }

        }
        foreach (var stick in sticks4.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                sticks4.Remove(stick);
                rowDelete = 3;
                stickDeleted++;
            }


        }
        foreach (var stick in sticks5.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                sticks5.Remove(stick);
                rowDelete = 3;
                stickDeleted++;
            }


        }*/

        historyTable.GetComponent<HistoryTable>().setText(LuotDi, rowDelete + "-"+stickDeleted);


        
        Unlock();

        if (LuotDi == 1)
        {
            Player.GetComponent<Player>().setAnim();
        }
        else if (LuotDi == 2)
        {
            if (Bot.GetComponent<Bot>().isActiveAndEnabled)
            {
                Bot.GetComponent<Player>().setAnim();
            }
            else
            {
                Player2.GetComponent<Player>().setAnim();
            }

        }

        LuotDi = Math.Abs(LuotDi - 3);
        if( LuotDi == 1)
        {
            turn1.SetActive(true);
            turn2.SetActive(false);
        }
        else
        {
            turn2.SetActive(true);
            turn1.SetActive(false);
        }
        
        
        timedown();


    }

    public void SelectSticks1()
    {
        selectedList = rowList[1];
        lockList(rowList[1]);
        
    }

    public void SelectSticks2()
    {
        selectedList = rowList[2];
        lockList(rowList[2]);
        
    }

    public void SelectSticks3()
    {
        selectedList = rowList[3];
        lockList(rowList[3]);
        
    }

    public void SelectSticks4()
    {
        selectedList = rowList[4];
        lockList(rowList[4]);
        
    }
    public void SelectSticks5()
    {
        selectedList = rowList[5];
        lockList(rowList[5]);
        
    }


    private void lockList(List<GameObject> listToEnable)
    {
        for (int i = 1; i <= numRows; i++)
        {
            if (rowList[i] != listToEnable)
            {
                foreach (GameObject obj in rowList[i])
                {
                    obj.GetComponent<Button>().interactable = false;
                }
            }
        }
        /*foreach (List<GameObject> list in new List<List<GameObject>> { sticks1, sticks2, sticks3 , sticks4, sticks5})
        {
            if (list != listToEnable)
            {
                foreach (GameObject obj in list)
                {
                    obj.GetComponent<Button>().interactable = false;
                }
            }
        }*/

        foreach (GameObject obj in listToEnable)
        {

            obj.GetComponent<Button>().interactable = true;
        }
    }

    public void Unlock()
    {
        /*List<List<GameObject>> allLists = new List<List<GameObject>> { sticks1, sticks2, sticks3, sticks4, sticks5};

        foreach (List<GameObject> list in allLists)
        {
            foreach (GameObject obj in list)
            {

                obj.SetActive(true);
                obj.GetComponent<Button>().interactable = false;


            }
        }*/
        for (int i = 1; i <= numRows; i++)
        {
            {
                foreach (GameObject obj in rowList[i])
                {
                    obj.SetActive(true);
                    obj.GetComponent<Button>().interactable = false;
                }
            }
        }

    }

    public void lockAll()
    {
        /*List<List<GameObject>> allLists = new List<List<GameObject>> { sticks1, sticks2, sticks3, sticks4, sticks5};

        foreach (List<GameObject> list in allLists)
        {
            foreach (GameObject obj in list)
            {

                obj.SetActive(true);
                obj.GetComponent<Button>().interactable = false;


            }
        }*/
        for (int i = 1; i <= numRows; i++)
        {
            {
                foreach (GameObject obj in rowList[i])
                {
                    obj.SetActive(true);
                    obj.GetComponent<Button>().interactable = false;
                }
            }
        }

    }

    void checkSubmit()
    {
        for (int i = 1; i <= numRows; i++)
        {
            {
                foreach (GameObject stick in rowList[i])
                {
                    if (!stick.activeInHierarchy)
                    {
                        submit.interactable = true;

                    }
                }
            }
        }
        /*foreach (var stick in sticks1.ToList())
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
        foreach (var stick in sticks4.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                submit.interactable = true;

            }

        }
        foreach (var stick in sticks5.ToList())
        {
            if (!stick.activeInHierarchy)
            {
                submit.interactable = true;

            }

        }*/


    }

    public List<GameObject> getsticks(int i)
    {
        return rowList[i];
        /*if(i == 1)return sticks1;
        if(i == 2) return sticks2;
        if(i == 3) return sticks3;
        if (i == 4) return sticks4;
        if (i == 5) return sticks5;*/
        //return null;
    }

    public void BotChoose(int row, int sticks)
    {
        int r = row + 1;
        int s = sticks;
        Debug.Log("Bot choose:"+r + "-" + s);
        int k = 0;
        foreach (var stick in rowList[r].ToList())
        {
            if (k < sticks)
            {

                
                stick.SetActive(false);
                //sticks1.Remove(stick);
                k++;

            }

        }
        /*if(r == 1)
        {
            foreach (var stick in sticks1.ToList())
            {
                if (k < sticks)
                {
                    stick.SetActive(false);
                    //sticks1.Remove(stick);
                    k++;

                }

            }
        }
        if (r == 2)
        {
            foreach (var stick in sticks2.ToList())
            {
                if (k < sticks)
                {
                    stick.SetActive(false);
                    //sticks2.Remove(stick);
                    k++;

                }

            }
        }
        if (r == 3)
        {
            foreach (var stick in sticks3.ToList())
            {
                if (k < sticks)
                {
                    stick.SetActive(false);
                   // sticks3.Remove(stick);
                    k++;

                }

            }
        }
        if (r == 4)
        {
            foreach (var stick in sticks4.ToList())
            {
                if (k < sticks)
                {
                    stick.SetActive(false);
                    // sticks3.Remove(stick);
                    k++;

                }

            }
        }
        if (r == 5)
        {
            foreach (var stick in sticks5.ToList())
            {
                if (k < sticks)
                {
                    stick.SetActive(false);
                    // sticks3.Remove(stick);
                    k++;

                }

            }
        }*/
        removeStick();

    }

   

}
