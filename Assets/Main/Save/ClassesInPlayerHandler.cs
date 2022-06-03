using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class ClassesInPlayerHandler
{
    public PlayerStatusForReference playerStatus_status;
    public string playerStatus_name;
    public List<int> playerBattleCommand_IdList = new List<int>();
    public List<int> playerInventory_IdList = new List<int>();
    public List<int> playerInventory_CountList = new List<int>();
    public List<int> playerTrainingCommand_List = new List<int>();
    public List<int> playerStudyCommand_IdList = new List<int>();
    public List<int> playerStudyCommand_CountList = new List<int>();
    public List<int> playerEatCommand_IdList = new List<int>();
    public List<int> playerBuff_BuffList = new List<int>();

    public ClassesInPlayerHandler(GameObject from)
    {
        passPlayerDataHandler(from);
    }

    private void passPlayerDataHandler(GameObject from)
    {
        this.playerStatus_status = from.GetComponent<PlayerStatus>().playerStatusForReference;
        this.playerBattleCommand_IdList = from.GetComponent<PlayerBattleCommandList>().IdList;
        this.playerInventory_IdList = from.GetComponent<PlayerInventory>().IdList;
        this.playerInventory_CountList = from.GetComponent<PlayerInventory>().countList;
        this.playerTrainingCommand_List = from.GetComponent<PlayerTrainingCommandsList>().IdList;
        this.playerStudyCommand_IdList = from.GetComponent<PlayerStudyCommandsList>().IdList;
        this.playerStudyCommand_CountList = from.GetComponent<PlayerStudyCommandsList>().count;
        this.playerEatCommand_IdList = from.GetComponent<PlayerEatCommandsList>().IdList;
        this.playerBuff_BuffList = from.GetComponent<PlayerBuff>().buff_list;
        this.playerStatus_name = from.GetComponent<PlayerStatus>().name;
    }
}
