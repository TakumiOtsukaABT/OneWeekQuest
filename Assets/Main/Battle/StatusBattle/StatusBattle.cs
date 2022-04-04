using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBattle : PlayerStatus
{
    public int order;
    public characterType characterType;
    public new string name;
    public int MaxHP;
    public ElementEnum weakness;
    public ElementEnum sightWeakness;
    public ElementEnum resist;
    [ReadOnly] private bool alive = true;
    [ReadOnly] public bool barrier = false;


    [SerializeField] private GameObject healthBar;
    private void Start()
    {
        MaxHP = base.playerStatusForReference.HP_access;
        healthBar.GetComponent<ValueBar>().SetMaxHealth(MaxHP);
    }

    public void setAlive(bool newState)
    {
        alive = newState;
    }

    public bool getAlive()
    {
        return alive;
    }

    public void takeDamage(int damage)
    {
        setHP(playerStatusForReference.HP_access - damage);
    }

    public void setBarrier(bool barrierState)
    {
        barrier = barrierState;
    }

    private void setHP(int new_hp)
    {
        playerStatusForReference.HP_access = new_hp;
        healthBar.GetComponent<ValueBar>().SetHealth(playerStatusForReference.HP_access);
        if(playerStatusForReference.HP_access < 0)
        {
            playerStatusForReference.HP_access = 0;
        }
        if (playerStatusForReference.HP_access > MaxHP)
        {
            playerStatusForReference.HP_access = MaxHP;
        }
    }

    public void heal(int healAmount)
    {
        setHP(playerStatusForReference.HP_access+healAmount);
    }
}
public enum characterType
{
    Human,
    Dog,
    Cat,
    Alpaca,
    Enemy
}