using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum State
    {
        idle,
        run,
        attack,
        Died
    }
    public State state;
    public event EventHandler OnEnemyIdle;
    public event EventHandler OnEnemyRun;
    public event EventHandler OnEnemyAttack;
    public event EventHandler OnEnemyHunt;
    public event EventHandler OnEnemyDied;

    //攻击和追赶的目标
    private Transform target;

    private float HP = 20;
    private float HPMax = 20;

    private float runSpeed = 3.0f;
    private float attackDistance = 1.0f;

    private float catchUpTime = 2.0f;
    private bool isDied;

    private void Start()
    {
        state = State.idle;
        OnEnemyIdle?.Invoke(this, EventArgs.Empty);
    }
    private void Update()
    {
        switch (state)
        {
            case State.idle:
                OnEnemyIdle?.Invoke(this, EventArgs.Empty);
                break;
            case State.run:
                OnEnemyRun?.Invoke(this, EventArgs.Empty);
                transform.position += transform.forward * Time.deltaTime * runSpeed;
                break;
            case State.attack:
                OnEnemyAttack?.Invoke(this, EventArgs.Empty);
                catchUpTime = 2.5f;
                break;
            case State.Died:
                if (!isDied) 
                {
                    enemyDiedBefore();
                    OnEnemyDied?.Invoke(this, EventArgs.Empty);
                    Invoke("DestroySelf", 3.0f);
                    isDied = !isDied;
                    TaskManager.Instance.UpdateData();
                   
                }
                break;
        }
        if (state == State.Died) return;

        if (target != null) 
        {
            
            //玩家在攻击范围内
            if (attackDistance > Vector3.Distance(transform.position, target.position))
            {
                transform.LookAt(target);
                
                state = State.attack;
            }
            //玩家不在攻击范围内
            else
            {
                catchUpTime -= Time.deltaTime;
                state = State.idle;
                if (catchUpTime < 0) 
                {
                    transform.LookAt(target);
                    state = State.run;
                }   
            }
        }
     
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            target = other.gameObject.transform;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Sword")
        {
            switch (Player.Instance.state)
            {
                case Player.State.idle:
                   
                    return;
                case Player.State.normalAttack:
                    HP--;
                    OnEnemyHunt?.Invoke(this, EventArgs.Empty);
                
                    break;
                case Player.State.skillOne:
                    HP -= 5;
                
                    OnEnemyHunt?.Invoke(this, EventArgs.Empty);
                    break;
                case Player.State.skillTwo:
                    HP -= 10;
                
                    OnEnemyHunt?.Invoke(this, EventArgs.Empty);
                    break;
            }
            if (HP <= 0)
            {
                state = State.Died;
            }
        }
    }
    public float GetHP()
    {
        return HP;
    }
    public float GetHPMax() 
    {
        return HPMax;
    }

    private void enemyDiedBefore() 
    {
        transform.GetComponent<CapsuleCollider>().enabled = false;
        transform.GetComponent<Rigidbody>().useGravity = false;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
        Player.Instance.experience += 10;
    }
}
