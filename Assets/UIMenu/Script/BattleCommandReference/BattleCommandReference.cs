using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/BattleCommandReference")]
public class BattleCommandReference : ScriptableObject
{
    public List<BattleCommand> battleCommands = new List<BattleCommand>();

    public BattleCommand GetBattleCommand(int id)
    {
        foreach(var i in battleCommands)
        {
            if (i.id.Equals(id))
            {
                return i;
            }
        }
        return null;
    }
}