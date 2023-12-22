using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigRedBottleProp : Prop
{
    private const string BIG_RED_BOTTLE_NUM = "BigRedBottleNum";
    
    private void Awake()
    {
        description = "»Ö¸´ËùÓÐHP";
        propNumber = PlayerPrefs.GetInt(BIG_RED_BOTTLE_NUM, 5);
    }
    public override void UseProp()
    {
        propNumber--;
        Player.Instance.playerHP = Player.Instance.playerHPMax;
        PlayerPrefs.SetInt(BIG_RED_BOTTLE_NUM, propNumber);
    }
}
