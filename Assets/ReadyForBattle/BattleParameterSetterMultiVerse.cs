using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleParameterSetterMultiVerse : MonoBehaviour
{
    [SerializeField, ReadOnly] GameObject playerDataHandler;
    [ReadOnly] StatusBattle alpacaStatusBattle;
    [ReadOnly] StatusBattle dogStatusBattle;
    [ReadOnly] StatusBattle catStatusBattle;
    [ReadOnly] StatusBattle characterStatusBattle;

    bool alpacaActive = false;
    bool dogActive = false;
    bool catActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerDataHandler = GameObject.Find("PlayerDataHandlerMultiVerse");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
