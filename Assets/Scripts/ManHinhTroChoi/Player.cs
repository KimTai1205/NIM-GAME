using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator anim;
    [SerializeField] int ID;
    // Start is called before the first frame update
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void setAnim()
    {
        anim.SetTrigger("send");
        Debug.Log("send");
        anim.SetTrigger("back");
        Debug.Log("back");
    }
}
