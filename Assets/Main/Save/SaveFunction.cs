using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFunction : MonoBehaviour
{
    public GameObject playerdataHandler;
    // Start is called before the first frame update
    void Start()
    {
        StreamWriter writer;
        PlayerStatus status = playerdataHandler.GetComponent<PlayerStatus>();

        string jsonstr = JsonUtility.ToJson(status);

        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

}

class unko
{
    public int i = 0;
    public int j = 10;
}