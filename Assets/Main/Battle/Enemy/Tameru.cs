using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tameru : EnemyBaseCommand
{
    protected override IEnumerator chooseTarget()
    {
        yield return new WaitForSeconds(0.0f);
        int attack = gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Attack_access;
        //Debug.Log(dialogues[0]);
        string[] tameteiru = new string[2];
        tameteiru[0] = "‚Ü‚¨‚¤‚ÍUŒ‚‚ğ’™‚ß‚Ä‚¢‚é!";
        tameteiru[1] = "";
        gameDirector_3.setDialogue(tameteiru);
        gameDirector_3.Single_target = gameDirector_3.Enemy;
        activeCharacters.Clear();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
