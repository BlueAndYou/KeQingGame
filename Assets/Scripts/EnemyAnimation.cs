using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private const string ISRUN = "IsRun";
    private const string ATTACK = "Attack";
    private const string DIED = "Died";
    private Enemy enemy;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }
    private void Start()
    {
        enemy.OnEnemyIdle += Enemy_OnEnemyIdle;
        enemy.OnEnemyRun += Enemy_OnEnemyRun;
        enemy.OnEnemyAttack += Enemy_OnEnemyAttack;
        enemy.OnEnemyDied += Enemy_OnEnemyDied;
    }

    private void Enemy_OnEnemyDied(object sender, System.EventArgs e)
    {
        PlayDiedAnimation();
    }

    private void Enemy_OnEnemyAttack(object sender, System.EventArgs e)
    {
        animator.SetBool(ISRUN, false);
        animator.SetTrigger(ATTACK);
    }

    private void Enemy_OnEnemyRun(object sender, System.EventArgs e)
    {
        PlayRunAnimation();
    }

    private void Enemy_OnEnemyIdle(object sender, System.EventArgs e)
    {
        PlayIdleAnimation();
    }

    private void Update()
    {
        
    }

    private void PlayRunAnimation()
    {
        animator.SetBool(ISRUN,true);
    }

    private void PlayIdleAnimation()
    {
        animator.SetBool(ISRUN, false);
    }
    private void PlayAttackAnimation()
    {
        animator.SetTrigger(ATTACK);
    }
    private void PlayDiedAnimation() 
    {
        animator.SetTrigger(DIED);
    }
}
