using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMessageUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Grade;
    [SerializeField]
    private Image expressionProgress;
    [SerializeField]
    private Image HPProgress;
    [SerializeField]
    private TextMeshProUGUI HPText;
    [SerializeField]
    private Image MPProgress;
    [SerializeField]
    private TextMeshProUGUI MPText;

    

    private void Start()
    {
        Grade.text = Player.Instance.GetPlayerGrade().ToString();
        expressionProgress.fillAmount = Player.Instance.GetExperience() / Player.Instance.GetExperienceMax();
        HPProgress.fillAmount = Player.Instance.GetPlayerHP() / Player.Instance.GetExperienceMax();
        MPProgress.fillAmount = Player.Instance.GetPlayerMP() / Player.Instance.GetPlayerHPMax();
        HPText.text = ((int)Player.Instance.GetPlayerHP()).ToString() + "/" + Player.Instance.GetPlayerHPMax().ToString();
        MPText.text = ((int)Player.Instance.GetPlayerMP()).ToString() + "/" + Player.Instance.GetPlayerMPMax().ToString();

    }

    private void Update()
    {
        Grade.text = Player.Instance.GetPlayerGrade().ToString();
        expressionProgress.fillAmount = Player.Instance.GetExperience() / Player.Instance.GetExperienceMax();
        HPProgress.fillAmount = Player.Instance.GetPlayerHP() / Player.Instance.GetPlayerHPMax();
        MPProgress.fillAmount = Player.Instance.GetPlayerMP() / Player.Instance.GetPlayerHPMax();
        HPText.text = ((int)Player.Instance.GetPlayerHP()).ToString() + "/" + Player.Instance.GetPlayerHPMax().ToString();
        MPText.text = ((int)Player.Instance.GetPlayerMP()).ToString() + "/" + Player.Instance.GetPlayerMPMax().ToString();

    }
}
