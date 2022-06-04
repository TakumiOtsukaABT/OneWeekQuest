using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;



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
            ClassesInPlayerHandler PH = JsonUtility.FromJson<ClassesInPlayerHandler>(datastr);
            SceneManager.LoadScene(PH.Day);
        } catch (FileNotFoundException)
        {
            GameObject.Find("AlertCanvas").GetComponent<AlertScript>().Activate("セーブファイルが見つかりません");
        }
     }
}
