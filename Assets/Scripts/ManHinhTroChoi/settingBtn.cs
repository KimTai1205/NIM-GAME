using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingBtn : MonoBehaviour
{
    public GameObject table;


    public void show()
    {
        table.SetActive(true);
        
    }

    public void hide()
    {
        table.SetActive(false);
        
    }

    public void newgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainmenu()
    {
        GameObject goSN = GameObject.FindGameObjectWithTag("SoNguoiChoi") as GameObject;
        goSN.SetActive(false);
        GameObject goSound = GameObject.FindGameObjectWithTag("backgroundAudio") as GameObject;
        goSound.SetActive(false);
        SceneManager.LoadScene("ManHinhDanhMuc");
    }
}
