using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandContent : BaseContent<BattleCommand,BattleCommandReference>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<BattleCommandPrefabSetter>().nameText = base.battleCommandReference.GetElement(i).element_name;
        base.prefab.GetComponent<BattleCommandPrefabSetter>().costText = base.battleCommandReference.GetElement(i).cost;
    }
}
