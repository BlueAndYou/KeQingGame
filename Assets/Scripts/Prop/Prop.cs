using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public  class Prop : MonoBehaviour
{
    [SerializeField]
    protected PropSO propSO;


    public event EventHandler OnPropUse;
    protected int propNumber = 10;
    //道具的描述信息
    protected string description;

    public void HandleUseProp() 
    {
        OnPropUse?.Invoke(this, EventArgs.Empty);
    }
    public virtual void UseProp()
    {
        propNumber--; 
    }

    public int GetNumber() 
    {
        return propNumber;
    }

    public string GetDescription() 
    {
        return description;
    }

    public PropSO GetPropSO() 
    {
        return propSO;
    }

    //道具使用完
    public void UsedUp()
    {
        BagManager.Instance.UsedUp(propSO);
    }

}
