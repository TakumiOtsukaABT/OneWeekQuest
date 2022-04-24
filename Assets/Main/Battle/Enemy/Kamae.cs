using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamae : EnemyBaseCommand
{
    protected override IEnumerator chooseTarget()
    {
        yield return new WaitForSeconds(0.0f);
        //Debug.Log(dialogues[0]);
        string[] tameteiru = new string[2];
        tameteiru[0] = "Ç‹Ç®Ç§ÇÕç\Ç¶ÇéÊÇ¡ÇƒÇ¢ÇÈ!";
        tameteiru[1] = "";
        gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().kamae = true;
        gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().kamaeAmount = 0;
        gameDirector_3.setDialogue(tameteiru);
        gameDirector_3.Single_target = gameDirector_3.Enemy;
        activeCharacters.Clear();
        gameDirector_3.resetState(BattleState.Read, battleEffect: base.Effect);
    }
}
