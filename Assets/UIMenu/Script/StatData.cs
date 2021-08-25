using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatData : MonoBehaviour
{
    public BaseStatus mystatus;

    [SerializeField] TextMeshProUGUI HP;
    [SerializeField] TextMeshProUGUI MP;
    [SerializeField] TextMeshProUGUI power;
    [SerializeField] TextMeshProUGUI Defence;
    [SerializeField] TextMeshProUGUI speed;
    [SerializeField] TextMeshProUGUI hit;
    [SerializeField] TextMeshProUGUI regen;
    private void OnEnable()
    {
        HP.text = mystatus.HP1.ToString();
        MP.text = mystatus.MP1.ToString();
        power.text = mystatus.Attack1.ToString();
        Defence.text = mystatus.Defence1.ToString();
        speed.text = mystatus.Speed1.ToString();
        hit.text = mystatus.HitRate1.ToString();
        regen.text = mystatus.Regen1.ToString();
    }
}
