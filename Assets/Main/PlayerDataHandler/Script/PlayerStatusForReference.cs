using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerStatusForReference
{
    [SerializeField] private int HP;
    [SerializeField] private int MP;
    [SerializeField] private int Attack;
    [SerializeField] private int Defence;
    [SerializeField] private int Speed;
    [SerializeField] private int HitRate;
    [SerializeField] private int Regen;

    public int HP_access { get => HP; set => HP = value; }
    public int MP_access { get => MP; set => MP = value; }
    public int Attack_access { get => Attack; set => Attack = value; }
    public int Defence_access { get => Defence; set => Defence = value; }
    public int Speed_access { get => Speed; set => Speed = value; }
    public int HitRate_access { get => HitRate; set => HitRate = value; }
    public int Regen_access { get => Regen; set => Regen = value; }

    public void increment(PlayerStatusForReference playerStatusForReferenceInc)
    {
        HP += playerStatusForReferenceInc.HP_access;
        MP += playerStatusForReferenceInc.MP_access;
        Attack += playerStatusForReferenceInc.Attack_access;
        Defence += playerStatusForReferenceInc.Defence_access;
        Speed += playerStatusForReferenceInc.Speed_access;
        HitRate += playerStatusForReferenceInc.HitRate_access;
        Regen += playerStatusForReferenceInc.Regen_access;
    }
}