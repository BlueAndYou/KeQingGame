using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    [SerializeField]
    private List<PropSO> propSOList;

    public event EventHandler OnPropUsedUp;


    public static BagManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public List<PropSO> GetPropSOList() 
    {
        return propSOList;
    }
    public void UsedUp(PropSO propSO) 
    {
        for (int i = 0; i < propSOList.Count; i++)
        {
            if (propSOList[i] == propSO)
            {
                propSOList.Remove(propSO);
                OnPropUsedUp?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
