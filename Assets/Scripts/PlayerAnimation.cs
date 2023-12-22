using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   
    private const string NORMAL_ATTACK = "NormalAttack";
    private const string SKILL_ONE = "SkillOne";
    private const string SKILL_TWO = "SkillTwo";
    private const string DIED = "Died";

    private const string IDLE = "InputMagnitude";
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Player.Instance.OnNormalAttackAnimationPlay += Player_OnNormalAttackAnimationPlay;
        Player.Instance.OnSkillOneAnimationPlay += Player_OnSkillOneAnimationPlay;
        Player.Instance.OnSkillTwoAnimationPlay += Player_OnSkillTwoAnimationPlay;
        Player.Instance.OnPlayerDied += Player_OnPlayerDied;
    }

    private void Player_OnPlayerDied(object sender, System.EventArgs e)
    {
        PlayDiedAnimation();
    }

    private void Player_OnSkillTwoAnimationPlay(object sender, System.EventArgs e)
    {
        PlaySkillTwoAnimation();
    }

    private void Player_OnSkillOneAnimationPlay(object sender, System.EventArgs e)
    {
        PlaySkillOneAnimation();
    }
   
    private void Player_OnNormalAttackAnimationPlay(object sender, System.EventArgs e)
    {
        PlayNormalAttackAnimation();
    }

    private void PlaySkillOneAnimation() 
    {
        animator.SetTrigger(SKILL_ONE); 
    }
    private void PlaySkillTwoAnimation() 
    {
        animator.SetTrigger(SKILL_TWO);
    }

    private void PlayNormalAttackAnimation() 
    {
        animator.SetTrigger(NORMAL_ATTACK);
    }
    private void PlayDiedAnimation() 
    {
        animator.SetTrigger(DIED);
    }

    public void PlayIdleAnimation() 
    {
        animator.SetFloat(IDLE, 0);
    }

}
