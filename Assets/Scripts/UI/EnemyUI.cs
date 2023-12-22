using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField]
    private Image enemyHPProgressImage;
    [SerializeField]
    private Enemy enemy;

    private void Start()
    {
        enemy.OnEnemyHunt += Enemy_OnEnemyHunt;
        ChangeHPProgress();
    }

    private void Enemy_OnEnemyHunt(object sender, System.EventArgs e)
    {
        ChangeHPProgress();
    }

    public void ChangeHPProgress() 
    {
        enemyHPProgressImage.fillAmount = enemy.GetHP() / enemy.GetHPMax();
    }
}
