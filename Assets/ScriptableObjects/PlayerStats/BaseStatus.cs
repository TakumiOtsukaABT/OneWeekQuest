using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable")]
public class BaseStatus : ScriptableObject
{
    [SerializeField] private int HP;
    [SerializeField] private int MP;
    [SerializeField] private int Attack;
    [SerializeField] private int Defence;
    [SerializeField] private int Speed;
    [SerializeField] private int HitRate;
    [SerializeField] private int Regen;

    public int HP1 { get => HP; set => HP = value; }
    public int MP1 { get => MP; set => MP = value; }
    public int Attack1 { get => Attack; set => Attack = value; }
    public int Defence1 { get => Defence; set => Defence = value; }
    public int Speed1 { get => Speed; set => Speed = value; }
    public int HitRate1 { get => HitRate; set => HitRate = value; }
    public int Regen1 { get => Regen; set => Regen = value; }
}
