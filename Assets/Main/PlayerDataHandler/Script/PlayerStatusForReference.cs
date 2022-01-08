using System;
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

    public void increment(PlayerStatusForReference playerStatusForReferenceInc, float multiplier)
    {
        HP += Convert.ToInt32(playerStatusForReferenceInc.HP_access*multiplier);
        MP += Convert.ToInt32(playerStatusForReferenceInc.MP_access * multiplier);
        Attack += Convert.ToInt32(playerStatusForReferenceInc.Attack_access * multiplier);
        Defence += Convert.ToInt32(playerStatusForReferenceInc.Defence_access * multiplier);
        Speed += Convert.ToInt32(playerStatusForReferenceInc.Speed_access * multiplier);
        HitRate += Convert.ToInt32(playerStatusForReferenceInc.HitRate_access * multiplier);
        Regen += Convert.ToInt32(playerStatusForReferenceInc.Regen_access * multiplier);
    }
}
