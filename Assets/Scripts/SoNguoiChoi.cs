using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoNguoiChoi : MonoBehaviour
{
    public string SoNguoi;
   

    private void Awake() 
    {
        DontDestroyOnLoad(this); // ko bi xoa khi thoat sence ma chuyen qua sence MHTT
    }
}
