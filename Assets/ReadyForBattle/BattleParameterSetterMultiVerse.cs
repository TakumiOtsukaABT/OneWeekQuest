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

    [SerializeField, ReadOnly] GameObject AlpacaImage;
    [SerializeField, ReadOnly] GameObject DogImage;
    [SerializeField, ReadOnly] GameObject CatImage;
    [SerializeField, ReadOnly] GameObject CharacterImage;
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
        AlpacaImage =  GameObject.Find("AlpacaImage");
        DogImage = GameObject.Find("DogImage");
        CatImage = GameObject.Find("CatImage");
        CharacterImage = GameObject.Find("CharacterImage");
        setActiveAndAlive(ref AlpacaImage, alpacaActive);
        setActiveAndAlive(ref DogImage, dogActive);
        setActiveAndAlive(ref CatImage, catActive);
        setParameters(ref CharacterImage, characterStatusBattle);
        setParameters(ref AlpacaImage, alpacaStatusBattle);
        setParameters(ref DogImage, dogStatusBattle);
        setParameters(ref CatImage, catStatusBattle);
    }

    private void setParameters(ref GameObject _gameObject, BattleParameterStorer parameterStorer)
    {
        StatusBattle status = _gameObject.GetComponent<StatusBattle>();
        status.playerStatusForReference = parameterStorer.playerStatusForReference;
        status.name = parameterStorer.name;
        status.battleCommandID = parameterStorer.battleCommandIdList;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene("Battle");
        }
    }


    private void setActiveAndAlive(ref GameObject obj, bool active)
    {
        obj.SetActive(active);
        obj.GetComponent<StatusBattle>().setAlive(active);
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