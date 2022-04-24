using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitoriKougeki : EnemyBaseCommand
{
    protected override IEnumerator chooseTarget()
    {
        yield return new WaitForSeconds(0.0f);
        int attack = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        if (gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().tameru)
        {
            attack = attack * 2;
            gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().tameru = false;
        }
        if (kamaed)
        {
            attack = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().kamaeAmount;
            kamaed = false;
        }
        List<string> dialogues = new List<string>();
        GameObject highestHPObject = activeCharacters[0];
        for (int i = 0; i < activeCharacters.Count; i++)
        {
            if(highestHPObject.GetComponent<StatusBattle>().playerStatusForReference.HP_access < activeCharacters[i].GetComponent<StatusBattle>().playerStatusForReference.HP_access)
            {
                highestHPObject = activeCharacters[i];
            }
        }
        int defence = highestHPObject.GetComponent<StatusBattle>().playerStatusForReference.Defence_access;
        int attackMinusDefence = attack - defence;
        if (attackMinusDefence < 0)
        {
            attackMinusDefence = 0;
        }
        int damage = Mathf.RoundToInt(((attackMinusDefence) * Random.Range(2.0f, 2.3f)) + Random.Range(1.0f, 10.0f));
        gameDirector_3.Single_target = highestHPObject;
        gameDirector_3.setTakeDamageAndDialogue(damage);
        activeCharacters.Clear();

        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
