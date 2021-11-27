using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyCommandContent : BaseContent<StudyCommand,StudyReference,PlayerStudyCommandsList>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<GrowthCommandPrefabSetter>().nameText = base.battleCommandReference.GetElement(i).element_name;
    }
}
