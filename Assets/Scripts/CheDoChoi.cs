using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   

public class CheDoChoi : MonoBehaviour
{
    public GameObject SoNguoiChoi; //Keo Object SoNguoiChoi
    public string SoNguoi;

    private void Start()
    {
        Screen.SetResolution(1280,800,false);
    }
    public void NguoiChoi()
    {
        SoNguoiChoi.GetComponent<SoNguoiChoi>().SoNguoi = SoNguoi;
        SceneManager.LoadScene("ManHinhTroChoi");
    }

}
