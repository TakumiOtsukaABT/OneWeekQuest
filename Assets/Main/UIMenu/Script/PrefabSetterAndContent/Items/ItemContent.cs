using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContent : BaseContent<Item,ItemReference>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<ItemPrefabSetter>().nameText = base.battleCommandReference.GetElement(i).element_name;
        base.prefab.GetComponent<ItemPrefabSetter>().costText = base.battleCommandReference.GetElement(i).count;
    }
}
