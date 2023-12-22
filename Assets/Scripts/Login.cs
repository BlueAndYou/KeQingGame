using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : UserSQL
{
    [SerializeField]
    private Button loginButton;
    [SerializeField]
    private Transform loginPage;
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
    private Transform loginState;
    [SerializeField]
    private TextMeshProUGUI stateText;
    [SerializeField]
    private Transform register;
    [SerializeField]
    private Transform quit;

    private void Start()
    {
        loginButton.onClick.AddListener(()=>
        {
            ShowLoginPage();
            HideRegisterAndQuit();
        });
        close.onClick.AddListener(() => 
        {
            HideLoginPage();
            ShowRegisterAndQuit();
            passwordInput.text = "";
            usernameInput.text = "";
        });
        submit.onClick.AddListener(() => 
        {
            SubmitLogin();
        });

    }
    private void SubmitLogin()
    {
        username = Convert.ToInt32(usernameInput.text);
        password = passwordInput.text;
        if (IsCanLogin(username,password))
        {
            stateText.text = "ÕýÔÚµÇÂ¼";
            ShowLoginState();
            Invoke("HideLoginState", 2f);

            Invoke("JoinGame", 2f);
        }
        else
        {
            stateText.text = "ÕËºÅ»òÕßÃÜÂë´íÎó";
            ShowLoginState();
            Invoke("HideLoginState", 2f);
        }
    }

    private void JoinGame() 
    {
        LoaderScene.LoadScene(LoaderScene.Scene.HomeScene);
    }
    private void HideLoginState() 
    {
        loginState.gameObject.SetActive(false);
    }
    private void ShowLoginState()
    {
        loginState.gameObject.SetActive(true);
    }
    private void HideLoginPage() 
    {
        loginPage.gameObject.SetActive(false);    
    }
    private void ShowLoginPage() 
    {
        loginPage.gameObject.SetActive(true);
    }

    private void HideRegisterAndQuit() 
    {
        quit.gameObject.SetActive(false);
        register.gameObject.SetActive(false);
        loginButton.gameObject.SetActive(false);
    }

    private void ShowRegisterAndQuit()
    {
        quit.gameObject.SetActive(true);
        register.gameObject.SetActive(true);
        loginButton.gameObject.SetActive(true);
    }
}
