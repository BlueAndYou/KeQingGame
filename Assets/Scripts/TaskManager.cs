using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private const String SAVESTATE = "SaveState";
    [SerializeField]
    private TextMeshProUGUI taskContent;
    public static TaskManager Instance { get; private set; }

    private const string GANYU_TASK = "GanYuTask";
    private const string DEFEAT_NUM = "DefeatNum";
    private string task;

    public int defeatNum = 0;

    private int defeatNumMax = 5;


    private void Awake()
    {
        Instance = this;
        taskContent.text = task = PlayerPrefs.GetString(GANYU_TASK, "ÔİÎŞÈÎÎñ");
        defeatNum = PlayerPrefs.GetInt(DEFEAT_NUM, 0);
        SaveData();
    }
    private void Start()
    {

        DialogueManager.Instance.OnTasking += DialogueManager_OnTasking;

    }

    private void DialogueManager_OnTasking(object sender, System.EventArgs e)
    {
        ReceiveTask();
    }

    public void ReceiveTask()
    {
        defeatNum = 0;
        PlayerPrefs.SetInt(DEFEAT_NUM, defeatNum);
        task = $"¸ÊÓêµÄ¼ÄÍĞ:»÷É±÷¼÷Ã¹Ö{defeatNum}/{defeatNumMax}";
        taskContent.text = task;
        PlayerPrefs.SetString(GANYU_TASK, task);
    }

    public void SaveData()
    {
        PlayerPrefs.SetString(GANYU_TASK, task);
        PlayerPrefs.SetInt(DEFEAT_NUM, defeatNum);
        PlayerPrefs.Save();
    }
    public void UpdateData()
    {
        defeatNum++;
        if (defeatNum >= defeatNumMax)
        {
            taskContent.text = task = "¸ÊÓêµÄ¼ÄÍĞ£ºOK";
            DialogueManager.Instance.state = DialogueManager.State.Done;
            PlayerPrefs.SetInt(SAVESTATE, 3);
        }
        else
        {
            taskContent.text = task = $"¸ÊÓêµÄ¼ÄÍĞ:»÷É±÷¼÷Ã¹Ö{defeatNum}/{defeatNumMax}";
        }
        SaveData();
    }

    public int GetDefeatNumMax()
    {
        return defeatNumMax;
    }

    public void SetTask(string task)
    {
        taskContent.text = this.task = task;
        PlayerPrefs.SetString(GANYU_TASK, task);
    }
}
