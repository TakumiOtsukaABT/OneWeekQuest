using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleParameterSetterMultiVerse : MonoBehaviour
{
    [SerializeField, ReadOnly] GameObject playerDataHandler;
    [SerializeField, ReadOnly] BattleParameterStorer alpacaStatusBattle = new BattleParameterStorer();
    [SerializeField, ReadOnly] BattleParameterStorer dogStatusBattle = new BattleParameterStorer();
    [SerializeField, ReadOnly] BattleParameterStorer catStatusBattle = new BattleParameterStorer();
    [SerializeField, ReadOnly] BattleParameterStorer characterStatusBattle = new BattleParameterStorer();

    [SerializeField, ReadOnly] bool alpacaActive = false;
    [SerializeField, ReadOnly] bool dogActive = false;
    [SerializeField, ReadOnly] bool catActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerDataHandler = GameObject.Find("PlayerDataHandlerMultiVerse");
        //for (int i = 0; i<100;i++)
        //{

        //        characterStatusBattle.playerStatusForReference = playerDataHandler.GetComponent<PlayerStatus>().playerStatusForReference;
        //        characterStatusBattle.name = playerDataHandler.GetComponent<PlayerStatus>().name;
        //}
        //後はここから、インベントリから仲間の有無、バトルコマンドの設定

        PlayerInventory inventory = playerDataHandler.GetComponent<PlayerInventory>();
        foreach(var i in inventory.IdList)
        {
            checkActiveAllies(ref alpacaActive, i, 21);
            checkActiveAllies(ref dogActive, i, 11);
            checkActiveAllies(ref catActive, i, 15);
        }
    }

    private void checkActiveAllies(ref bool activeFlag, int iteration, int flagID)
    {
        if(iteration == flagID)
        {
            activeFlag = true;
        }
    }

    private void setStatusBattle(StatusBattle to)
    {

    }
}

public class BattleParameterStorer
{

}