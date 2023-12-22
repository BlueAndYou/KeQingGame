using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBothPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;
    private void Update()
    {
        if (transform.childCount == 0) 
        {
            Transform Enemy =  Instantiate(EnemyPrefab,transform.position,Quaternion.identity).transform;
            Enemy.SetParent(transform);
        }
    }
}
