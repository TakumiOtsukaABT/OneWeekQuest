using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFunctions : MonoBehaviour
{
    [SerializeField] private GameObject name_object;
    [SerializeField] private GameObject count_object;

    [SerializeField] private string _name;
    [SerializeField] private int _count;

    public string nameText
    {
        get { return _name; }
        set { _name = value;
            name_object.GetComponent<Text>().text = _name;}
    }
    public int countText
    {
        get { return _count; }
        set
        {
            _count = value;
            count_object.GetComponent<Text>().text = _count.ToString();
        }
    }
}
