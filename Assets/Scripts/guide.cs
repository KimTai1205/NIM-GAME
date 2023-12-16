using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guide : MonoBehaviour
{

    public GameObject table;

   
    public void show_guide()
    {
         
        table.GetComponent<guideanim>().show_guide();



    }
    public void hide_guide()
    {

        table.GetComponent<guideanim>().hide_guide();


    }

}
