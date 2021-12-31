using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBattle : PlayerStatus
{
    public int order;
    public characterType characterType;
    public new string name;

    [SerializeField] private GameObject healthBar;
    private void Start()
    {
        int maxHealth = base.playerStatusForReference.HP_access;
        healthBar.GetComponent<ValueBar>().SetMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        setHP(playerStatusForReference.HP_access - damage);
    }

    private void setHP(int new_hp)
    {
        playerStatusForReference.HP_access = new_hp;
        healthBar.GetComponent<ValueBar>().SetHealth(playerStatusForReference.HP_access);
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