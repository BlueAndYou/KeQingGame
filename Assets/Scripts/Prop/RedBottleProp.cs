using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBottleProp : Prop
{
    private const string RED_BOTTLE_NUM = "RedBottleNum";

    private void Awake()
    {
        description = "据说有神奇的魔法，使用后可以回复50点生命值";
        propNumber = PlayerPrefs.GetInt(RED_BOTTLE_NUM, 10);
    }
    public override void UseProp()
    {
        propNumber--;
        Player.Instance.playerHP += 50;
        if (Player.Instance.playerHP > Player.Instance.playerHPMax)
            Player.Instance.playerHP = Player.Instance.playerHPMax;
        PlayerPrefs.SetInt(RED_BOTTLE_NUM, propNumber);

    }
}
