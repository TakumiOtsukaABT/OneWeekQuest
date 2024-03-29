using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBattle : PlayerStatus
{
    public int order;
    public characterType characterType;
    [ReadOnly] private int MaxHP;
    [ReadOnly] private int MaxMP;
    public ElementEnum weakness;
    public ElementEnum sightWeakness;
    public ElementEnum resist;
    [SerializeField,ReadOnly] private bool alive = true;
    [ReadOnly] public bool barrier = false;
    public List<int> battleCommandID = new List<int>();
    [ReadOnly] public bool tameru = false;
    [ReadOnly] public bool guard = false;
    [ReadOnly] public bool kamae = false;
    [ReadOnly] public int kamaeAmount = 0;



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
        if (kamae&&characterType.Equals(characterType.Enemy)) { kamaeAmount += damage; }
        setHP(playerStatusForReference.HP_access - damage);
    }

    public void setBarrier(bool barrierState)
    {
        barrier = barrierState;
    }

    public int getMaxHP()
    {
        return MaxHP;
    }

    private void setHP(int new_hp)
    {
        playerStatusForReference.HP_access = new_hp;
        if(playerStatusForReference.HP_access <= 0)
        {
            playerStatusForReference.HP_access = 0;
            alive = false;
        }
        if (playerStatusForReference.HP_access > MaxHP)
        {
            playerStatusForReference.HP_access = MaxHP;
        }
        healthBar.GetComponent<ValueBar>().SetHealth(playerStatusForReference.HP_access);
    }

    public void setMP(int new_mp)
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
        MPBar.GetComponent<ValueBar>().SetHealth(playerStatusForReference.MP_access);
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