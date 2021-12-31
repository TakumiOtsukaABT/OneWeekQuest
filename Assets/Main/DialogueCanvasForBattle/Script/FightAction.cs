using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class FightAction : BaseActionCommand
{
    [SerializeField,ReadOnly] private GameObject targetCharacter;
    [SerializeField, ReadOnly] private GameObject currentCharacter;
    [SerializeField, ReadOnly] private GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;

    [SerializeField] private Event _event;

    public override void runActionCommand()
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        gameDirector_3.resetState(BattleState.SelectTarget);
        gameDirector_3.selectingType = SelectingType.Single;
        selectTarget();
    }

    private void selectTarget()
    {
        StartCoroutine(chooseTarget());
    }
    IEnumerator chooseTarget()
    {
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        int attack = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        int defence = gameDirector_3.Single_target.GetComponent<StatusBattle>().playerStatusForReference.Defence_access;
        int attackMinusDefence = attack - defence;
        if (attackMinusDefence < 0)
        {
            attackMinusDefence = 0;
        }
        int damage = Mathf.RoundToInt(((attackMinusDefence) * Random.Range(1.0f, 1.3f))+Random.Range(1.0f,10.0f));
        gameDirector_3.setTakeDamageAndDialogue(damage);
        gameDirector_3.resetState(BattleState.Read);
    }
}
