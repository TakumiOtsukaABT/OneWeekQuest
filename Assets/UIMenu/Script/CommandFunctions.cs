using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandFunctions : MonoBehaviour
{
    [SerializeField] private GameObject name_object;
    [SerializeField] private GameObject cost_object;

    [SerializeField] private string _name;
    [SerializeField] private int cost;

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
