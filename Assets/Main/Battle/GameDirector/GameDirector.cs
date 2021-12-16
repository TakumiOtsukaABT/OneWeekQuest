using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class GameDirector : MonoBehaviour
{
    [SerializeField, ReadOnly] private BattleState battleState = BattleState.Read;
    [SerializeField, ReadOnly] private InputControllerForBattle inputController_2;
    [SerializeField, ReadOnly] private BattleGameCanvasController battleGameCanvasController_0;

    // Start is called before the first frame update
    void Start()
    {
        battleGameCanvasController_0 = GetComponent<Outlet>().gameObjects[0].GetComponent<BattleGameCanvasController>();
        inputController_2 = GetComponent<Outlet>().gameObjects[2].GetComponent<InputControllerForBattle>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            battleState++;
            resetState(battleState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            battleState--;
            resetState(battleState);
        }
    }

    public void resetState(BattleState newState)
    {
        StartCoroutine(deactivate_then_activate_state(newState));
    }

    IEnumerator deactivate_then_activate_state(BattleState newState)
    {
        battleGameCanvasController_0.deactivateAll();
        yield return new WaitForSeconds(0.5f);
        setState(newState);
    }


    private void setState(BattleState newState)
    {
        battleState = newState;
        switch (newState)
        {
            case BattleState.WaitingInput:
                Debug.Log("waiting input");
                battleGameCanvasController_0.atWaitingInput();
                inputController_2.setInputHandle<Battle_CommandInputHandle>();

                break;
            case BattleState.Read:
                Debug.Log("read");
                battleGameCanvasController_0.atRead();
                inputController_2.setInputHandle<Battle_ReadInputHandle>();
                break;
            case BattleState.SelectTarget:
                Debug.Log("select target");
                battleGameCanvasController_0.atSelectTarget();
                inputController_2.setInputHandle<Battle_CommandInputHandle>();
                break;
            case BattleState.Status:
                Debug.Log("status");
                battleGameCanvasController_0.atStatus();
                inputController_2.setInputHandle<Battle_CommandInputHandle>();
                break;
        }
    }
}
