using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WazaContent : MonoBehaviour
{
    public GameObject dialogueCanvasCommand;
    public List<GameObject> techniquePrefabs =  new List<GameObject>();
    private Outlet outlet;
    void OnEnable()
    {
        outlet = dialogueCanvasCommand.GetComponent<Outlet>();
        GameDirector gameDirector = outlet.gameObjects[3].GetComponent<GameDirector>();
        List<int> idList = gameDirector.getCurrentCharacter().GetComponent<StatusBattle>().battleCommandID;
        foreach(var i in GameObject.FindGameObjectsWithTag("Waza"))
        {
            Destroy(i);
        }
        foreach(int i in idList)
        {
            GameObject instantiated = Instantiate(techniquePrefabs[i], this.transform);
            instantiated.GetComponent<WazaAction>().dialogueCanvasCommand = dialogueCanvasCommand;
            instantiated.GetComponent<Button>().onClick.AddListener(() => {
                dialogueCanvasCommand.GetComponent<DialogueCanvasCommand>().onButtonClick(instantiated);
            });
        }
    }
}
