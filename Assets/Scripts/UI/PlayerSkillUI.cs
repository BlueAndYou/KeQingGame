using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillUI : MonoBehaviour
{
    [SerializeField]
    private Image skillOneProgress;
    [SerializeField]
    private Image skillTwoProgress;

    


    private void Start()
    {
        skillOneProgress.fillAmount = Player.Instance.GetSkillOneCDTimer()/Player.Instance.GetSkillOneCD();
        skillTwoProgress.fillAmount = Player.Instance.GetSkillTwoCDTimer()/Player.Instance.GetSkillTwoCD();
    }

    private void Update()
    {
        skillOneProgress.fillAmount = Player.Instance.GetSkillOneCDTimer() / Player.Instance.GetSkillOneCD();
        skillTwoProgress.fillAmount = Player.Instance.GetSkillTwoCDTimer() / Player.Instance.GetSkillTwoCD();
    }
}
