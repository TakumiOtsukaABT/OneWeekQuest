using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReadyForBattleDialogueController : DialogueCanvasController
{
    public string battleSceneName;
    public BlackoutController blackout;
    protected override void setInputHandleBack()
    {
        //inputController_1.setInputHandle<CharacterMovementInputHandle>();
        inputController_1.setInputHandle<MenuInputHandle>();
        StartCoroutine(waitActiveFadeout());
    }

    IEnumerator waitActiveFadeout()
    {
        blackout.ActivateFadeout();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Battle");
    }

    protected override void tickTask()
    {
        //base.tickTask();
    }
}
