using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInputField : MonoBehaviour
{
    public string name_character;
    public Text text;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
    public void onClickConfirm()
    {
        name_character = text.text;
        SceneManager.LoadScene("Town");
    }

    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject playerDataHandler = GameObject.Find("PlayerDataHandler");
        GameObject playerDataHandlerMultiVerse = GameObject.Find("PlayerDataHandlerMultiVerse");
        playerDataHandler.GetComponent<PlayerStatus>().name = name_character;
        playerDataHandlerMultiVerse.GetComponent<PlayerStatus>().name = name_character;
        SceneManager.sceneLoaded -= SceneLoaded;
    }
}
