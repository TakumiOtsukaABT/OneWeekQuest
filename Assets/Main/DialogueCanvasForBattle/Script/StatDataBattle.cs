using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDataBattle : StatData
{
    public StatusBattle character;
    [SerializeField] TextMeshProUGUI Name;

    private void OnEnable()
    {
        base.mystatus = character.playerStatusForReference;
        Name.text = character.name.ToString();
        base.updateText();
    }
}
