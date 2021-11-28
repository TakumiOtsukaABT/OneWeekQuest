using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContent : BaseContent<Item,ItemReference,PlayerInventory>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<ItemPrefabSetter>().nameText = base.uniqueCommandReference.GetElement(i).element_name;
        base.prefab.GetComponent<ItemPrefabSetter>().costText = base.uniqueCommandReference.GetElement(i).count;
    }
}
