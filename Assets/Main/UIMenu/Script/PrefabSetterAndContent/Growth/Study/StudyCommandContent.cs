using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyCommandContent : BaseContent<StudyCommand,StudyReference,PlayerStudyCommandsList>
{
    protected override void setPrefab(int i)
    {
        base.prefab.GetComponent<GrowthCommandPrefabSetter>().nameText = base.uniqueCommandReference.GetElement(i).element_name;
    }

    protected override void setListener(int i)
    {
        base.setListener(i);
        base.board.GetComponent<StudyBoard>().id = base.uniqueCommandReference.GetElement(i).id;
    }
}
