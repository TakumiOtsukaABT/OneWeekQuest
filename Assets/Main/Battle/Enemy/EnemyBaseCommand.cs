using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseCommand : BaseActionCommand
{
    [SerializeField, ReadOnly] protected GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;
    public List<GameObject> activeCharacters = new List<GameObject>();
    protected bool kamaed = false;

    public override void runActionCommand()
    {
        initialSetupObjects(SelectingType.Single);
        selectTarget();
    }

    protected void initialSetupObjects(SelectingType selecting)
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        activeCharacters = gameDirector_3.activeCharacters;
        gameDirector_3.selectingType = selecting;
        if (gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().guard)
        {
            gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().guard = false;
            gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Defence_access -= 50;
        }
        if (gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().kamae) kamaed = true;
        gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().kamae = false;
    }
    protected void selectTarget()
    {
        StartCoroutine(chooseTarget());
    }

    protected virtual IEnumerator chooseTarget()
    {
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
    }

}
