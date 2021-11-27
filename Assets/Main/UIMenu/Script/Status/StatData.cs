using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatData : MonoBehaviour
{
    private PlayerStatusForReference mystatus;
    [SerializeField] Outlet outlet;

    [SerializeField] TextMeshProUGUI HP;
    [SerializeField] TextMeshProUGUI MP;
    [SerializeField] TextMeshProUGUI power;
    [SerializeField] TextMeshProUGUI Defence;
    [SerializeField] TextMeshProUGUI speed;
    [SerializeField] TextMeshProUGUI hit;
    [SerializeField] TextMeshProUGUI regen;
    private void OnEnable()
    {
        mystatus = outlet.gameObjects[0].GetComponent<PlayerStatus>().playerStatusForReference;
        HP.text = mystatus.HP_access.ToString();
        MP.text = mystatus.MP_access.ToString();
        power.text = mystatus.Attack_access.ToString();
        Defence.text = mystatus.Defence_access.ToString();
        speed.text = mystatus.Speed_access.ToString();
        hit.text = mystatus.HitRate_access.ToString();
        regen.text = mystatus.Regen_access.ToString();
    }
}
