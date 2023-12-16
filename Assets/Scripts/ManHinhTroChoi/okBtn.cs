using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class okBtn : MonoBehaviour
{
    public void  OnButtonClick()
    {
        this.GetComponent<Button>().onClick.Invoke();
    }
}
