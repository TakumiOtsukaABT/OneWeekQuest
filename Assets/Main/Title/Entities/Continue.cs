using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Continue : MonoBehaviour
{
    string datastr = "";
    StreamReader reader;
    public void Onclick()
    {
        try {
            reader = new StreamReader(Application.dataPath + "/savedata.json");
            datastr = reader.ReadToEnd();
            reader.Close();
        } catch (FileNotFoundException)
        {
            GameObject.Find("AlertCanvas").GetComponent<AlertScript>().Activate("セーブファイルが見つかりません");
        }
     }
}
