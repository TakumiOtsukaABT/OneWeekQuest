using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReadyForBattleDialogueController : DialogueCanvasController
{
    public string battleSceneName;
    protected override void setInputHandleBack()
    {
        //inputController_1.setInputHandle<CharacterMovementInputHandle>();
        inputController_1.setInputHandle<MenuInputHandle>();
        SceneManager.LoadScene("Battle");
    }

    protected override void tickTask()
    {
        //base.tickTask();
    }
}
