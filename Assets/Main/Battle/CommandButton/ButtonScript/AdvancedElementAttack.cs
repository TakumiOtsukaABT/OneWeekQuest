using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedElementAttack : ElementAttackAction
{
    [SerializeField] private float advanceRate;
    protected override IEnumerator chooseTarget()
    {
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
        Debug.Log("ran untilwait");
        Debug.Log(gameDirector_3.getFlagDoneSelecting());
        int attack = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        int defence = gameDirector_3.Single_target.GetComponent<StatusBattle>().playerStatusForReference.Defence_access;
        int attackMinusDefence = Mathf.RoundToInt(attack*advanceRate) - defence;
        if (attackMinusDefence < 0)
        {
            attackMinusDefence = 0;
        }
        int damage = Mathf.RoundToInt(((attackMinusDefence) * Random.Range(1.0f, 1.3f)) + Random.Range(1.0f, 10.0f));
        seeElementComp();
        gameDirector_3.setTakeDamageAndDialogue(Mathf.RoundToInt(damage * bairitsu));
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
