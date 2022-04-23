using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseCommand : BaseActionCommand
{
    [SerializeField, ReadOnly] protected GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;
    public List<GameObject> activeCharacters = new List<GameObject>();


    public override void runActionCommand()
    {
        initialSetupObjects(SelectingType.Single);
        selectTarget();
    }

    protected void initialSetupObjects(SelectingType selecting)
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        if (gameDirector_3.Human.activeSelf) activeCharacters.Add(gameDirector_3.Human);
        if (gameDirector_3.Dog.activeSelf) activeCharacters.Add(gameDirector_3.Dog);
        if (gameDirector_3.Cat.activeSelf) activeCharacters.Add(gameDirector_3.Cat);
        if (gameDirector_3.Alpaca.activeSelf) activeCharacters.Add(gameDirector_3.Alpaca);
        gameDirector_3.selectingType = selecting;
    }
    protected void selectTarget()
    {
        StartCoroutine(chooseTarget());
    }

    protected virtual IEnumerator chooseTarget()
    {
        yield return new WaitUntil(gameDirector_3.getFlagDoneSelecting);
    }

}
