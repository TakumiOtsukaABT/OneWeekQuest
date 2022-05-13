using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingDialogueCanvas : DialogueCanvasController
{
    public List<string> endDialogue = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        inputController_1 = GetComponent<Outlet>().gameObjects[1].GetComponent<InputController>();
        Dialogue = endDialogue.ToArray();
        ActivateCanvasWithDialogueArray();
    }

    protected override void setInputHandleBack()
    {
        inputController_1.setInputHandle<EndingInputHandle>();
    }

    IEnumerator showClear()
    {
        GameObject.Find("Blackout").GetComponent<BlackoutController>().ActivateFadeout();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("TitleScene");
    }

    protected override void tickTask()
    {    }
}
