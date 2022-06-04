using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFunction : MonoBehaviour
{
    public GameObject playerdataHandler;
    void Start()
    {
        StreamWriter writer;
        ClassesInPlayerHandler classesInPlayerDataHandler = new ClassesInPlayerHandler(playerdataHandler);
        string jsonstr = JsonUtility.ToJson(classesInPlayerDataHandler, true);
        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
}