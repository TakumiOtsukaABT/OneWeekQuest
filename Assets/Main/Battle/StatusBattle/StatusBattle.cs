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
    public int MaxMP;
    public ElementEnum weakness;
    public ElementEnum sightWeakness;
    public ElementEnum resist;
    [ReadOnly] private bool alive = true;
    [ReadOnly] public bool barrier = false;


    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject MPBar;

    private void Start()
    {
        MaxHP = base.playerStatusForReference.HP_access;
        healthBar.GetComponent<ValueBar>().SetMaxHealth(MaxHP);
        if (!(characterType == characterType.Enemy))
        {
            MaxMP = base.playerStatusForReference.MP_access;
            MPBar.GetComponent<ValueBar>().SetMaxHealth(MaxMP);
        }
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
        if(playerStatusForReference.HP_access < 0)
        {
            playerStatusForReference.HP_access = 0;
        }
        if (playerStatusForReference.HP_access > MaxHP)
        {
            playerStatusForReference.HP_access = MaxHP;
        }
        healthBar.GetComponent<ValueBar>().SetHealth(playerStatusForReference.HP_access);
    }

    private void setMP(int new_mp)
    {
        playerStatusForReference.MP_access = new_mp;
        if (playerStatusForReference.MP_access < 0)
        {
            playerStatusForReference.MP_access = 0;
        }
        if (playerStatusForReference.MP_access > MaxMP)
        {
            playerStatusForReference.MP_access = MaxMP;
        }
        healthBar.GetComponent<ValueBar>().SetHealth(playerStatusForReference.MP_access);
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