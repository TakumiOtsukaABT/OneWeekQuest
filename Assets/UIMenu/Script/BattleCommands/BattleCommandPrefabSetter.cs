using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandPrefabSetter : MonoBehaviour//TODO: keisho
{
    [SerializeField] private GameObject name_object;
    [SerializeField] private GameObject cost_object;

    [SerializeField,ReadOnly] private string _name;
    [SerializeField,ReadOnly] private int cost;

    public string nameText
    {
        get { return _name; }
        set { _name = value;
            name_object.GetComponent<Text>().text = _name;}
    }
    public int costText
    {
        get { return cost; }
        set
        {
            cost = value;
            cost_object.GetComponent<Text>().text = cost.ToString();
        }
    }
}
