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
    //���ߵ�������Ϣ
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

    //����ʹ����
    public void UsedUp()
    {
        BagManager.Instance.UsedUp(propSO);
    }

}
