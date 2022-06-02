using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFunction : MonoBehaviour
{
    public GameObject playerdataHandler;
    [SerializeField, ReadOnly] private PlayerStatus status;
    [SerializeField, ReadOnly] private PlayerBattleCommandList battleCommandList;
    [SerializeField, ReadOnly] private PlayerInventory playerInventory;
    [SerializeField, ReadOnly] private PlayerTrainingCommandsList playerTrainingCommandsList;
    [SerializeField, ReadOnly] private PlayerStudyCommandsList playerStudyCommandsList;
    [SerializeField, ReadOnly] private PlayerEatCommandsList playerEatCommandsList;
    [SerializeField, ReadOnly] private PlayerBuff playerBuff;
    // Start is called before the first frame update
    void Start()
    {
        StreamWriter writer;
        setEveryComponent();
        ClassesInPlayerHandler classesInPlayerDataHandler = new ClassesInPlayerHandler();
        classesInPlayerDataHandler.status = status;
        //classesInPlayerDataHandler.playerInventory = playerInventory;
        //classesInPlayerDataHandler.playerTrainingCommandsList = playerTrainingCommandsList;
        //classesInPlayerDataHandler.playerStudyCommandsList = playerStudyCommandsList;
        //classesInPlayerDataHandler.playerEatCommandsList = playerEatCommandsList;
        //classesInPlayerDataHandler.playerBuff = playerBuff;
        string jsonstr = JsonUtility.ToJson(playerInventory,true);
        //jsonstr += JsonUtility.ToJson(battleCommandList);
        //jsonstr += JsonUtility.ToJson(playerInventory);
        //jsonstr += JsonUtility.ToJson(playerTrainingCommandsList);
        //jsonstr += JsonUtility.ToJson(playerStudyCommandsList);
        //jsonstr += JsonUtility.ToJson(playerEatCommandsList);
        //jsonstr += JsonUtility.ToJson(playerBuff);


        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    private void setEveryComponent()
    {
        status = playerdataHandler.GetComponent<PlayerStatus>();
        battleCommandList = playerdataHandler.GetComponent<PlayerBattleCommandList>();
        playerInventory = playerdataHandler.GetComponent<PlayerInventory>();
        playerTrainingCommandsList = playerdataHandler.GetComponent<PlayerTrainingCommandsList>();
        playerStudyCommandsList = playerdataHandler.GetComponent<PlayerStudyCommandsList>();
        playerEatCommandsList = playerdataHandler.GetComponent<PlayerEatCommandsList>();
        playerBuff = playerdataHandler.GetComponent<PlayerBuff>();
    }

}