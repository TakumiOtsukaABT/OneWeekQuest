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
}
