using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingCommandContent : BaseContent<TrainingCommand,TrainingReference,PlayerTrainingCommandsList>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<GrowthCommandPrefabSetter>().nameText = base.battleCommandReference.GetElement(i).element_name;
    }
}
