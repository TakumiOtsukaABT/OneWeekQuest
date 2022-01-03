using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDataBattle : StatData
{
    public GameObject character;
    [SerializeField] TextMeshProUGUI Name;

    private void OnEnable()
    {
        base.updateText();
    }
}
