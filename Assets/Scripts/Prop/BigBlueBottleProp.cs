using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigBlueBottleProp : Prop
{
    private const string BIG_BLUE_BOTTLE_NUM = "BigBlueBottleNum";
   
    private void Awake()
    {
        description = "传说中是甘雨制作的药剂，使用后回复所有的MP";
        propNumber = PlayerPrefs.GetInt(BIG_BLUE_BOTTLE_NUM, 5);
    }
    public override void UseProp()
    {
        propNumber--;
        Player.Instance.playerMP =Player.Instance.playerMPMax;
        PlayerPrefs.SetInt(BIG_BLUE_BOTTLE_NUM, propNumber);
    }
}
