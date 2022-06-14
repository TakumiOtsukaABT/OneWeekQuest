using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;


public class PlayerDataHandlerMultiVerse : MonoBehaviour
{
    [SerializeField, ReadOnly] GameObject playerDataHandler;
    private void OnEnable()
    {
        if (GameObject.Find("PlayerDataHandlerMultiVerse")!=gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        try
        {
            playerDataHandler = GameObject.Find("PlayerDataHandler");
            passPlayerDataHandler(gameObject, playerDataHandler);
        } catch(System.NullReferenceException)
        {
            Debug.Log("Not town scene nor the day scene");
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    public void saveFile()
    {
        StreamWriter writer;
        ClassesInPlayerHandler classesInPlayerDataHandler = new ClassesInPlayerHandler(this.gameObject);
        string jsonstr = JsonUtility.ToJson(classesInPlayerDataHandler, true);
        writer = new StreamWriter(Application.persistentDataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    private void passPlayerDataHandler(GameObject from, GameObject to)
    {
        to.GetComponent<PlayerStatus>().playerStatusForReference = from.GetComponent<PlayerStatus>().playerStatusForReference;
        to.GetComponent<PlayerBattleCommandList>().IdList = from.GetComponent<PlayerBattleCommandList>().IdList;
        to.GetComponent<PlayerInventory>().IdList = from.GetComponent<PlayerInventory>().IdList;
        to.GetComponent<PlayerInventory>().countList = from.GetComponent<PlayerInventory>().countList;
        to.GetComponent<PlayerTrainingCommandsList>().IdList = from.GetComponent<PlayerTrainingCommandsList>().IdList;
        to.GetComponent<PlayerStudyCommandsList>().IdList = from.GetComponent<PlayerStudyCommandsList>().IdList;
        to.GetComponent<PlayerStudyCommandsList>().count = from.GetComponent<PlayerStudyCommandsList>().count;
        to.GetComponent<PlayerEatCommandsList>().IdList = from.GetComponent<PlayerEatCommandsList>().IdList;
        to.GetComponent<PlayerBuff>().buff_list = from.GetComponent<PlayerBuff>().buff_list;
        to.GetComponent<PlayerStatus>().name = from.GetComponent<PlayerStatus>().name;
    }
}
