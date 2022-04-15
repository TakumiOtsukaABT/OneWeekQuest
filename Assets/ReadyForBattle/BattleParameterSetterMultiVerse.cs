using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BattleParameterSetterMultiVerse : MonoBehaviour
{
    [SerializeField, ReadOnly] GameObject playerDataHandler;
    [SerializeField] BattleParameterStorer alpacaStatusBattle = new BattleParameterStorer();
    [SerializeField] BattleParameterStorer dogStatusBattle = new BattleParameterStorer();
    [SerializeField] BattleParameterStorer catStatusBattle = new BattleParameterStorer();
    [SerializeField] BattleParameterStorer characterStatusBattle = new BattleParameterStorer();

    [SerializeField, ReadOnly] bool alpacaActive = false;
    [SerializeField, ReadOnly] bool dogActive = false;
    [SerializeField, ReadOnly] bool catActive = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneLoaded;
        playerDataHandler = GameObject.Find("PlayerDataHandlerMultiVerse");
        if (playerDataHandler)
        {
            PlayerInventory inventory = playerDataHandler.GetComponent<PlayerInventory>();
            foreach (var i in inventory.IdList)
            {
                checkActiveAllies(ref alpacaActive, i, 21);
                checkActiveAllies(ref dogActive, i, 11);
                checkActiveAllies(ref catActive, i, 15);
            }
            characterStatusBattle.playerStatusForReference = playerDataHandler.GetComponent<PlayerStatus>().playerStatusForReference;
            characterStatusBattle.name = playerDataHandler.GetComponent<PlayerStatus>().name;
            characterStatusBattle.battleCommandIdList = playerDataHandler.GetComponent<PlayerBattleCommandList>().IdList;
            Destroy(playerDataHandler);
        }

    }

    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {


    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene("Battle");
        }
    }

    private void checkActiveAllies(ref bool activeFlag, int iteration, int flagID)
    {
        if(iteration == flagID)
        {
            activeFlag = true;
        }
    }
}

[System.Serializable]
public class BattleParameterStorer
{
    public PlayerStatusForReference playerStatusForReference;
    public List<int> battleCommandIdList = new List<int>();
    public string name;
    public characterType characterType;
    public ElementEnum weakness;
    public ElementEnum sightWeakness;
    public ElementEnum resist;
}