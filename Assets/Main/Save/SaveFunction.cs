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
        alertScript_4.Activate("���̓��̎n�߂̏�Ԃ��Z�[�u���܂���", 0);
        GameObject.Find("PlayerDataHandlerMultiVerse").GetComponent<PlayerDataHandlerMultiVerse>().saveFile();
    }
}