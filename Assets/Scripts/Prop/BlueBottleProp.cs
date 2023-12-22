using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlueBottleProp : Prop
{
    private const string BLUE_BOTTLE_NUM = "BlueBottleNum";
    private void Awake()
    {
        description = "»Ö¸´50µãMP";
        propNumber = PlayerPrefs.GetInt(BLUE_BOTTLE_NUM, 10);
    }
    public override void UseProp()
    {
        propNumber--;
        Player.Instance.playerMP += 50;
        if (Player.Instance.playerMP > Player.Instance.playerMPMax)
            Player.Instance.playerMP = Player.Instance.playerMPMax;
        PlayerPrefs.SetInt(BLUE_BOTTLE_NUM, propNumber);
       

    }
}
