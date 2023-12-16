using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideanim : MonoBehaviour
{
       
        Animator anim;

        private void Awake()
        {
            anim = gameObject.GetComponent<Animator>();
        }
        public void show_guide()
        {

            anim.SetTrigger("show");



        }
        public void hide_guide()
        {

            anim.SetTrigger("hide");


    }
}
