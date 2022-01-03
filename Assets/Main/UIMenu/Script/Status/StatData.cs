using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatData : MonoBehaviour
{
    protected PlayerStatusForReference mystatus;
    [SerializeField] private Outlet outlet;

    [SerializeField] protected TextMeshProUGUI HP;
    [SerializeField] protected TextMeshProUGUI MP;
    [SerializeField] protected TextMeshProUGUI power;
    [SerializeField] protected TextMeshProUGUI Defence;
    [SerializeField] protected TextMeshProUGUI speed;
    [SerializeField] protected TextMeshProUGUI hit;
    [SerializeField] protected TextMeshProUGUI regen;
    private void OnEnable()
    {
        mystatus = outlet.gameObjects[0].GetComponent<PlayerStatus>().playerStatusForReference;
        updateText();
    }

    protected void updateText()
    {
        HP.text = mystatus.HP_access.ToString();
        MP.text = mystatus.MP_access.ToString();
        power.text = mystatus.Attack_access.ToString();
        Defence.text = mystatus.Defence_access.ToString();
        speed.text = mystatus.Speed_access.ToString();
        hit.text = mystatus.HitRate_access.ToString();
        regen.text = mystatus.Regen_access.ToString();
    }
}
