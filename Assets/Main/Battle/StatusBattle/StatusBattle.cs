using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBattle : PlayerStatus
{
    public int order;
    public characterType characterType;
}
public enum characterType
{
    Human,
    Dog,
    Cat,
    Alpaca,
    Enemy
}