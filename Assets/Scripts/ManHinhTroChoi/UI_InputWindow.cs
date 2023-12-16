using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System;

public class UI_InputWindow : MonoBehaviour
{
    private Button_UI okBtn;
    private TMP_InputField inputField;
    private TextMeshProUGUI titleText;
    private TextMeshProUGUI maxTurn;


    private void Awake()
    {
        okBtn = transform.Find("okBtn").GetComponent<Button_UI>();
        titleText = transform.Find("titleText").GetComponent<TextMeshProUGUI>();
        inputField = transform.Find("inputField").GetComponent<TMP_InputField>();
        maxTurn = transform.Find("maxTurn").GetComponent<TextMeshProUGUI>();

        //Hide();
    }

    private void Update()
    {
        // nhan Enter tu ban phim
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) 
        {
            okBtn.ClickFunc();
        }

    }

    public void Show(string titleString, string maxturn, string inputString, string validCharacters , int characterLimit,Action<string> onOK)
    {
        gameObject.SetActive(true);

        titleText.text = titleString;
        maxTurn.text = maxturn;

        inputField.characterLimit = characterLimit;
        inputField.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };

        inputField.text = inputString;

        okBtn.ClickFunc = () =>
        {
            Hide();
            onOK(inputField.text);
        };
           
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if(validCharacters.IndexOf(addedChar) != -1)
        {
            //Valid
            return addedChar;
        }else
        {
            //Invalid
            return '\0';
        }
    }
}
