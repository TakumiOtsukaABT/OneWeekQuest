using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveAction : BaseActionCommand
{
    [SerializeField, ReadOnly] protected GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;
    [SerializeField] float editMultiplier;
    public override void runActionCommand()
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        gameDirector_3.resetState(BattleState.SelectTarget);
        gameDirector_3.selectingType = SelectingType.Single;
        Debug.Log("ran until");
        selectTarget();
    }

    private void selectTarget()
    {
        StartCoroutine(chooseTarget());
    }
    virtual protected IEnumerator chooseTarget()
    {
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        Debug.Log("ran untilwait");
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        int regen = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Regen_access;
        gameDirector_3.setHealAndDialogue(Mathf.RoundToInt(regen * editMultiplier));
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
