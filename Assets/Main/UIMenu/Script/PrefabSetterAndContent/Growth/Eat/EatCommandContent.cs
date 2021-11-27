using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCommandContent : BaseContent<EatCommand,EatReference,PlayerEatCommandsList>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<GrowthCommandPrefabSetter>().nameText = base.battleCommandReference.GetElement(i).element_name;
    }
}
