using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleParameterSetterMultiVerse : MonoBehaviour
{
    [SerializeField, ReadOnly] GameObject playerDataHandler;
    [SerializeField, ReadOnly] StatusBattle alpacaStatusBattle;
    [SerializeField, ReadOnly] StatusBattle dogStatusBattle;
    [SerializeField, ReadOnly] StatusBattle catStatusBattle;
    [ReadOnly] StatusBattle characterStatusBattle;

    bool alpacaActive = false;
    bool dogActive = false;
    bool catActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerDataHandler = GameObject.Find("PlayerDataHandlerMultiVerse");
        characterStatusBattle.playerStatusForReference = playerDataHandler.GetComponent<PlayerStatus>().playerStatusForReference;
        characterStatusBattle.name = playerDataHandler.GetComponent<PlayerStatus>().name;
    }

    private void setStatusBattle(StatusBattle to)
    {

    }
}
