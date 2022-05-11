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
        if (character.characterType != characterType.Enemy)
        {
            base.updateText();
            HP.text = HP.text + "/" + character.getMaxHP();
        }
        else
        {
            updateTextToQuestion();
        }
        
    }
    private void updateTextToQuestion()
    {
        string question = "?????";
        HP.text = question;
        MP.text = question;
        power.text = question;
        Defence.text = question;
        speed.text = question;
        hit.text = question;
        regen.text = question;
    }

    protected override void nameUpdate()
    {
    }
}
