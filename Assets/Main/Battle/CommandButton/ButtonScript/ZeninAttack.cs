using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeninAttack : WazaAction
{
    [SerializeField] private ElementEnum thisElement;
    [SerializeField, ReadOnly] protected float bairitsu;

    override protected IEnumerator chooseTarget()
    {
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        int attack = gameDirector_3.Human.GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        attack += gameDirector_3.Dog.GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        attack += gameDirector_3.Cat.GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        attack += gameDirector_3.Alpaca.GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        int defence = gameDirector_3.Single_target.GetComponent<StatusBattle>().playerStatusForReference.Defence_access;
        int attackMinusDefence = attack - defence;
        if (attackMinusDefence < 0)
        {
            attackMinusDefence = 0;
        }
        int damage = Mathf.RoundToInt(((attackMinusDefence) * Random.Range(1.0f, 1.3f)) + Random.Range(1.0f, 10.0f));
        seeElementComp();
        gameDirector_3.setTakeDamageAndDialogue(Mathf.RoundToInt(damage * bairitsu));
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
