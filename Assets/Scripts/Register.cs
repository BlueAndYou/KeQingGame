using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Register : UserSQL
{
    [SerializeField]
    private Button registerButton;
    [SerializeField]
    private Transform registerAccountUI;
    [SerializeField]
    private TMP_InputField usernameInput;
    [SerializeField]
    private TMP_InputField passwordInput;
    private int username;
    private string password;
    [SerializeField]
    private Button submit;
    [SerializeField]
    private Button close;

    [SerializeField]
    private Transform registerState;
    [SerializeField]
    private TextMeshProUGUI stateText;
    [SerializeField]
    private Transform login;
    [SerializeField]
    private Transform quit;

    private void Start()
    {
        HideRegisterAccountUI();
        registerButton.onClick.AddListener(() =>
        {
            ShowRegisterAccountUI();
            HideLoginAndThis();
        });
        submit.onClick.AddListener(() =>
        {
            SubmitRegister();
            passwordInput.text = "";
            usernameInput.text = "";
        });
        HideRegisterState();

        close.onClick.AddListener(() => 
        {
            HideRegisterAccountUI();
            ShowLoginAndThis();
        });
    }

    private void SubmitRegister()
    {
        username = Convert.ToInt32(usernameInput.text);
        password = passwordInput.text;
        IsExit(username);
        if (!IsExit(username))
        {
            InsertUser(username, password);
            stateText.text = "×¢²á³É¹¦";
            ShowRegisterState();
            Invoke("HideRegisterState", 2f);
        }
        else 
        {
            stateText.text = "×¢²áÊ§°Ü\nÕËºÅÒÑ´æÔÚ";
            ShowRegisterState();
            Invoke("HideRegisterState", 2f);
        }
    }
    private void HideRegisterState() 
    {
        registerState.gameObject.SetActive(false);
    }
    private void ShowRegisterState()
    {
        registerState.gameObject.SetActive(true);
    }
    private void HideRegisterAccountUI()
    {
        registerAccountUI.gameObject.SetActive(false);
    }
    private void ShowRegisterAccountUI()
    {
        registerAccountUI.gameObject.SetActive(true);
    }

    private void ShowLoginAndThis() 
    {
        login.gameObject.SetActive(true);
        gameObject.SetActive(true);
        quit.gameObject.SetActive(true); 
    }
    private void HideLoginAndThis() 
    {
        login.gameObject.SetActive(false);
        gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }
}
