using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCommandContent : BaseContent<EatCommand,EatReference,PlayerEatCommandsList>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<GrowthCommandPrefabSetter>().nameText = base.uniqueCommandReference.GetElement(i).element_name;
    }

    protected override void setListener(int i)
    {
        base.setListener(i);
        base.board.GetComponent<EatBoard>().id = base.uniqueCommandReference.GetElement(i).id;
    }
}
