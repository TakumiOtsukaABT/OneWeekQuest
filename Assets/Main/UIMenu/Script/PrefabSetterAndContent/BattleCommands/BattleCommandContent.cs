using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandContent : BaseContent<BattleCommand,BattleCommandReference,PlayerBattleCommandList>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<BattleCommandPrefabSetter>().nameText = base.uniqueCommandReference.GetElement(i).element_name;
        base.prefab.GetComponent<BattleCommandPrefabSetter>().costText = base.uniqueCommandReference.GetElement(i).cost;
    }
}
