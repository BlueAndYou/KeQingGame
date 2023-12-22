using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string PLAYER_GRADE = "PlayerGrade";
    private const string PLAYER_HP = "PlayerHP";
    private const string PLAYER_MP = "PlayerMP";

    private const string PLAYER_EXPERIENCE = "PLayerExperience";

    public enum State
    {
        idle,
        normalAttack,
        skillOne,
        skillTwo,
        died
    }
    public State state;
    public event EventHandler OnNormalAttackAnimationPlay;
    public event EventHandler OnSkillOneAnimationPlay;
    public event EventHandler OnSkillTwoAnimationPlay;
    public event EventHandler OnPlayerDied;
    public int playerGrade;
    public float playerHP;
    public float playerMPMax;
    public float playerMP;
    public float playerHPMax;
    //经验
    public float experience;
    public float experienceMax;

    private float normalAttackTimer;
    [SerializeField]
    private float normalAttackCD = 3.0f;
    //技能
    private float SkillOneCD = 8f;
    private float SkillOneCDTimer = 8f;
    //消耗的蓝量
    private float sKillOneConsumption = 15;
    private float SkillTwoCD = 12;
    private float SkillTwoCDTimer = 12;
    private float sKillTwoConsumption = 20;


    private float upgradationAddHP = 50;
    private float upgradationAddMP = 80;
    public static Player Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        playerGrade = PlayerPrefs.GetInt(PLAYER_GRADE, 1);
        playerHP = PlayerPrefs.GetFloat(PLAYER_HP, 100.0f);
        playerMP = PlayerPrefs.GetFloat(PLAYER_MP, 100.0f);
        experience = PlayerPrefs.GetFloat(PLAYER_EXPERIENCE, 0);
        UpdateDate();


    }
    private void Start()
    {
        state = State.idle;
        PlayerInput.Instance.OnNormalAttack += PlayerInput_OnNormalAttack;
        PlayerInput.Instance.OnSkillOne += PlayerInput_OnSkillOne;
        PlayerInput.Instance.OnSkillTwo += PlayerInput_OnSkillTwo;

    }

    private void PlayerInput_OnSkillTwo(object sender, System.EventArgs e)
    {
        if (state != State.idle) return;
        //技能CD好，且MP大于等于技能需要的蓝量才能释放
        if (SkillTwoCDTimer >= SkillTwoCD && playerMP >= sKillTwoConsumption)
        {
            state = State.skillTwo;
            SkillTwoCDTimer = 0;
            playerMP -= sKillOneConsumption;
            OnSkillTwoAnimationPlay?.Invoke(this, e);
            Invoke("ChangeStateIdle", 2.5f);
        }
    }

    private void PlayerInput_OnSkillOne(object sender, System.EventArgs e)
    {
        if (state != State.idle) return;
        if (SkillOneCDTimer >= SkillOneCD && playerMP >= sKillOneConsumption)
        {
            state = State.skillOne;
            SkillOneCDTimer = 0;
            playerMP -= sKillOneConsumption;
            OnSkillOneAnimationPlay?.Invoke(this, e);
            Invoke("ChangeStateIdle", 2.5f);
        }
    }

    private void PlayerInput_OnNormalAttack(object sender, System.EventArgs e)
    {
        if (state != State.idle) return;
        if (normalAttackTimer > normalAttackCD)
        {
            state = State.normalAttack;
            normalAttackTimer = 0;
            OnNormalAttackAnimationPlay?.Invoke(this, e);
            Invoke("ChangeStateIdle", 2.5f);
        }
    }


    private void Update()
    {
        if (normalAttackTimer <= normalAttackCD)
            normalAttackTimer += Time.deltaTime;
        if (SkillOneCDTimer <= SkillOneCD)
            SkillOneCDTimer += Time.deltaTime;
        if (SkillTwoCDTimer <= SkillTwoCD)
            SkillTwoCDTimer += Time.deltaTime;

        //每秒回蓝量
        if (playerMP < playerMPMax)
        {
            playerMP += Time.deltaTime;
        }

        //升级
        if (experience >= experienceMax)
        {
            playerGrade++;
            experience = 0;
            UpdateDate();
            Upgradation();
        }
    }

    public void SavePlayerPrefabs()
    {
        PlayerPrefs.SetInt(PLAYER_GRADE, playerGrade);
        PlayerPrefs.SetFloat(PLAYER_HP, playerHP);
        PlayerPrefs.SetFloat(PLAYER_MP, playerMP);
        PlayerPrefs.SetFloat(PLAYER_EXPERIENCE, experience);
    }
    public void UpdateDate()
    {
        experienceMax = 10 + playerGrade * 20;
        playerHPMax = (playerGrade - 1) * upgradationAddHP + 100;
        playerMPMax = (playerGrade - 1) * upgradationAddMP + 100;
    }
    public void Upgradation()
    {
        playerHP += upgradationAddHP;
        playerMP += upgradationAddMP;
    }

    public float GetSkillOneCD()
    {
        return SkillOneCD;
    }
    public float GetSkillOneCDTimer()
    {
        return SkillOneCDTimer;
    }

    public float GetSkillTwoCD()
    {
        return SkillTwoCD;
    }
    public float GetSkillTwoCDTimer()
    {
        return SkillTwoCDTimer;
    }

    public int GetPlayerGrade()
    {
        return playerGrade;
    }
    public float GetPlayerMP()
    {
        return playerMP;
    }
    public float GetPlayerMPMax()
    {
        return playerMPMax;
    }
    public float GetPlayerHP()
    {
        return playerHP;
    }
    public float GetPlayerHPMax()
    {
        return playerHPMax;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy.state == Enemy.State.attack)
                {
                    playerHP -= 2;
                }
            }
        }
        //玩家死亡
        if (playerHP <= 0)
        {
            playerHP = 0;
            if (state != State.died)
            {
                state = State.died;
                OnPlayerDied?.Invoke(this, EventArgs.Empty);
            }

        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "EnemySword")
    //    {
    //        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
    //        {
    //            if (enemy.state == Enemy.State.attack)
    //            {
    //                Debug.Log(enemy.state);
    //                playerHP -= 10;
    //            }
    //        }
    //    }
    //}
    public float GetExperience()
    {
        return experience;
    }
    public float GetExperienceMax()
    {
        return experienceMax;
    }

    private void ChangeStateIdle()
    {
        state = State.idle;
    }


}
