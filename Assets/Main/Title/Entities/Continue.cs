using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;



public class Continue : MonoBehaviour
{
    string datastr = "";
    StreamReader reader;
    public GameObject playerMultiverse;
    public void Onclick()
    {
        try {
            reader = new StreamReader(Application.persistentDataPath + "/savedata.json");
            datastr = reader.ReadToEnd();
            reader.Close();
            ClassesInPlayerHandler PH = JsonUtility.FromJson<ClassesInPlayerHandler>(datastr);
            continueDataPass(playerMultiverse, PH);
            SceneManager.LoadScene(PH.Day);
        } catch (FileNotFoundException)
        {
            GameObject.Find("AlertCanvas").GetComponent<AlertScript>().Activate("セーブファイルが見つかりません");
        }
     }
    private void continueDataPass(GameObject playerMultiverse, ClassesInPlayerHandler classesInPlayer)
    {
        playerMultiverse.GetComponent<PlayerStatus>().playerStatusForReference = classesInPlayer.playerStatus_status;
        playerMultiverse.GetComponent<PlayerBattleCommandList>().IdList = classesInPlayer.playerBattleCommand_IdList;
        playerMultiverse.GetComponent<PlayerInventory>().IdList = classesInPlayer.playerInventory_IdList;
        playerMultiverse.GetComponent<PlayerInventory>().countList = classesInPlayer.playerInventory_CountList;
        playerMultiverse.GetComponent<PlayerTrainingCommandsList>().IdList = classesInPlayer.playerTrainingCommand_List;
        playerMultiverse.GetComponent<PlayerStudyCommandsList>().IdList = classesInPlayer.playerStudyCommand_IdList;
        playerMultiverse.GetComponent<PlayerStudyCommandsList>().count = classesInPlayer.playerStudyCommand_CountList;
        playerMultiverse.GetComponent<PlayerEatCommandsList>().IdList = classesInPlayer.playerEatCommand_IdList;
        playerMultiverse.GetComponent<PlayerBuff>().buff_list = classesInPlayer.playerBuff_BuffList;
        playerMultiverse.GetComponent<PlayerStatus>().name = classesInPlayer.playerStatus_name;
    }
}
