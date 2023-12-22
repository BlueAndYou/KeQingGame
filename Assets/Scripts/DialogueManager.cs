using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private const String SAVESTATE = "SaveState";
    public event EventHandler OnTasking;
    private List<string> ganYuMessageList;
    private List<string> playerMessageList;
    [SerializeField]
    private Image dialogueImage;
    [SerializeField]
    private Sprite ganYuImage;
    [SerializeField]
    private Sprite playerImage;
    [SerializeField]
    private TextMeshProUGUI message;
    private int ganYuMessageNum = 0;
    private int playerMessageNum = 0;

    [SerializeField]
    private NPC nPC;

    
    public static DialogueManager Instance { get; private set; }
    public enum State
    {
        Dialogue = 0,
        TaskDialogue = 1,
        Tasking = 2,
        Done = 3,
    }

    private bool done = true;
    public State state;
    private void Awake()
    {
        Instance = this;
        ganYuMessageList = new List<string>();
        playerMessageList = new List<string>();
        ganYuMessageList.Add("你好啊，我是甘雨，欢迎来到MyGame，最近外卖骷髅怪很多，你可以去消灭他们嘛");
        playerMessageList.Add("好啊，我当然想消灭这些可恶的骷髅怪");
        ganYuMessageList.Add($"那我给你一个任务吧，去消灭{TaskManager.Instance.GetDefeatNumMax()}个骷髅怪");
        playerMessageList.Add("好的，等我好消息");
        state = (State)PlayerPrefs.GetInt(SAVESTATE, 0);
    }

    private void Update()
    {

    }


    public void ShowMessage()
    {
        switch (state)
        {
            default:
            case State.Dialogue:
               
                if (ganYuMessageNum <= playerMessageNum)
                {
                    message.text = ganYuMessageList[ganYuMessageNum++];
                    dialogueImage.sprite = ganYuImage;
                }
                else 
                {
                    message.text = playerMessageList[playerMessageNum++];
                    dialogueImage.sprite = playerImage;
                }
                if (playerMessageList.Count == playerMessageNum)
                {
                    state = State.Tasking;
                    PlayerPrefs.SetInt(SAVESTATE, 2);
                    OnTasking?.Invoke(this, EventArgs.Empty);
                    nPC.HideDialogue();
                    return;
                }
                break;
            case State.TaskDialogue:
                message.text = "你还没完成任务，完成了在来找我，辛苦你了宝";
                dialogueImage.sprite = ganYuImage;
                state = State.Tasking;
                PlayerPrefs.SetInt(SAVESTATE, 2);
                break;
            case State.Tasking:
                nPC.HideDialogue();
                state = State.TaskDialogue;
                PlayerPrefs.SetInt(SAVESTATE, 2);
                break;
            case State.Done:
                if (done)
                {
                    message.text = "OK";
                    dialogueImage.sprite = ganYuImage;
                    done = false;
                }
                else 
                {
                    nPC.HideDialogue();
                    state = State.Dialogue;
                    PlayerPrefs.SetInt(SAVESTATE, 0);
                    TaskManager.Instance.SetTask("暂无任务");
                   
                }
                break;
        }
    }
    public void SetGanYuMessageNum(int num) 
    {
        ganYuMessageNum = num;
    }
    public void SetPlayerMessageNum(int num)
    {
        playerMessageNum = num;
    }
}

