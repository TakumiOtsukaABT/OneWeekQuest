using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFunction : MonoBehaviour
{
    public GameObject Menu;
    private Outlet outlet;
    [SerializeField, ReadOnly] private AlertScript alertScript_4;
    public void OnClick()
    {
        outlet = Menu.GetComponent<Outlet>();
        alertScript_4 = outlet.gameObjects[4].GetComponent<AlertScript>();
        alertScript_4.Activate("この日の始めの状態をセーブしました", 0);
        GameObject.Find("PlayerDataHandlerMultiVerse").GetComponent<PlayerDataHandlerMultiVerse>().saveFile();
    }
}