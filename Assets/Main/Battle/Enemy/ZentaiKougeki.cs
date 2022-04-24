using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZentaiKougeki : EnemyBaseCommand
{
    public override void runActionCommand()
    {
        initialSetupObjects(SelectingType.Multiple);
        selectTarget();
    }
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
        for (int i = 0; i < activeCharacters.Count; i++)
        {
            int defence = activeCharacters[i].GetComponent<StatusBattle>().playerStatusForReference.Defence_access;
            int attackMinusDefence = attack - defence;
            if (attackMinusDefence < 0)
            {
                attackMinusDefence = 0;
            }
            int damage = Mathf.RoundToInt(((attackMinusDefence) * Random.Range(1.0f, 1.3f)) + Random.Range(1.0f, 10.0f));
            gameDirector_3.Single_target = activeCharacters[i];
            dialogues.Add(gameDirector_3.setTakeDamageAndDialogue(damage));
        }
        //Debug.Log(dialogues[0]);

        gameDirector_3.setDialogue(dialogues.ToArray());
        gameDirector_3.targetted = new List<GameObject>(activeCharacters);
        activeCharacters.Clear();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect, multiple: true);
    }
}
