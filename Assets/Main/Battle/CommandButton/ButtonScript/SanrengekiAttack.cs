using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanrengekiAttack : BaseActionCommand
{
    [SerializeField, ReadOnly] protected GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;
    [SerializeField] private ElementEnum thisElement;
    [SerializeField, ReadOnly] protected float bairitsu;
    [SerializeField] int sanren;

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
        int attack = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        int defence = gameDirector_3.Single_target.GetComponent<StatusBattle>().playerStatusForReference.Defence_access;
        int attackMinusDefence = attack - defence;
        if (attackMinusDefence < 0)
        {
            attackMinusDefence = 0;
        }
        int damage = Mathf.RoundToInt(((attackMinusDefence) * Random.Range(1.0f, 1.3f)) + Random.Range(1.0f, 5.0f));
        seeElementComp();
        gameDirector_3.setTakeDamageAndDialogue(Mathf.RoundToInt(damage * bairitsu)*sanren);
        Debug.Log("damage");
        Debug.Log(damage);
        Debug.Log(bairitsu);
        Debug.Log(sanren);
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }

    protected void seeElementComp()
    {
        ElementEnum weakness = gameDirector_3.Single_target.GetComponent<StatusBattle>().weakness;
        ElementEnum resist = gameDirector_3.Single_target.GetComponent<StatusBattle>().resist;
        ElementEnum slightWeakness = gameDirector_3.Single_target.GetComponent<StatusBattle>().sightWeakness;
        if (thisElement == weakness)
        {
            bairitsu = 2.0f;
        }
        else if (thisElement == slightWeakness)
        {
            bairitsu = 1.5f;
        }
        else if (thisElement == resist)
        {
            bairitsu = 0.8f;
        }
        else
        {
            bairitsu = 1.0f;
        }
    }
}
