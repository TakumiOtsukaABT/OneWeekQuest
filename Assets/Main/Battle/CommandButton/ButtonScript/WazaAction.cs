using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WazaAction : BaseActionCommand
{
    [SerializeField, ReadOnly] protected GameDirector gameDirector_3;
    public GameObject dialogueCanvasCommand;
    public int cost;


    protected bool isMPEnough()
    {
        gameDirector_3 = dialogueCanvasCommand.GetComponent<Outlet>().gameObjects[3].GetComponent<GameDirector>();
        return cost < gameDirector_3.getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.MP_access;
    }

}
