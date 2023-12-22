using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField]
    private Button quit;
    void Start()
    {
        quit.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("IsPlayerStartAnimation", 1);
            Application.Quit();

        });
    }
}
