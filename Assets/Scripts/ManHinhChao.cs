using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManHinhChao : MonoBehaviour
{
    private float thoigiancho = 4.0f;

    // Update is called once per frame
    void Update()
    {
        //Sau 5s goi ManHinhDanhMuc
        if(thoigiancho <= 0.0f)
        {
            SceneManager.LoadScene("ManHinhDanhMuc");
        }
        else
        {
            thoigiancho -= Time.deltaTime; 
        }
    }
}
