using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingCommandContent : BaseContent<TrainingCommand,TrainingReference,PlayerTrainingCommandsList>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<GrowthCommandPrefabSetter>().nameText = base.uniqueCommandReference.GetElement(i).element_name;
    }

    protected override void setListener(int i)
    {
        base.setListener(i);
        base.board.GetComponent<TrainingBoard>().incrementPlayerStatus = base.uniqueCommandReference.GetElement(i).incrementStatus;
    }
}
