using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class GameDirector : MonoBehaviour
{
    private Queue<characterType> turn_queue = new Queue<characterType>();
    [SerializeField, ReadOnly] private BattleState battleState = BattleState.Read;
    [SerializeField, ReadOnly] private InputControllerForBattle inputController_2;
    [SerializeField, ReadOnly] private BattleGameCanvasController battleGameCanvasController_0;
    [SerializeField, ReadOnly] private GameObject human_3;
    [SerializeField, ReadOnly] private GameObject dog_4;
    [SerializeField, ReadOnly] private GameObject cat_5;
    [SerializeField, ReadOnly] private GameObject alpaca_6;
    [SerializeField, ReadOnly] private GameObject enemy_7;
    [SerializeField, ReadOnly] private characterType currentCharacter;

    private int[] sums = { 0, 0, 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        battleGameCanvasController_0 = GetComponent<Outlet>().gameObjects[0].GetComponent<BattleGameCanvasController>();
        inputController_2 = GetComponent<Outlet>().gameObjects[2].GetComponent<InputControllerForBattle>();
        human_3 = GetComponent<Outlet>().gameObjects[3];
        dog_4 = GetComponent<Outlet>().gameObjects[4];
        cat_5 = GetComponent<Outlet>().gameObjects[5];
        alpaca_6 = GetComponent<Outlet>().gameObjects[6];
        enemy_7 = GetComponent<Outlet>().gameObjects[7];
        initQueue();
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
        if (turn_queue.Count < 10)
        {
            turn_queue.Enqueue(GetNextEnque());
        }
    }


    private void setState(BattleState newState)
    {
        battleState = newState;
        switch (newState)
        {
            case BattleState.WaitingInput:
                Debug.Log("waiting input");
                currentCharacter = turn_queue.Dequeue();
                battleGameCanvasController_0.atWaitingInput(currentCharacter);
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

    private void initQueue()
    {
        StatusBattle[] speeds = new StatusBattle[5];
        speeds[0] = human_3.GetComponent<StatusBattle>();
        speeds[1] = dog_4.GetComponent<StatusBattle>();
        speeds[2] = cat_5.GetComponent<StatusBattle>();
        speeds[3] = alpaca_6.GetComponent<StatusBattle>();
        speeds[4] = enemy_7.GetComponent<StatusBattle>();

        while (turn_queue.Count < 10)
        {
            for (int i = 0; i < 5; i++)
            {
                sums[i] += speeds[i].playerStatusForReference.Speed_access;
                if (sums[i] > 1000)
                {
                    turn_queue.Enqueue(speeds[i].characterType);
                    sums[i] = sums[i] % 1000;
                }
            }
        }
    }

    private characterType GetNextEnque()
    {
        StatusBattle[] speeds = new StatusBattle[5];
        speeds[0] = human_3.GetComponent<StatusBattle>();
        speeds[1] = dog_4.GetComponent<StatusBattle>();
        speeds[2] = cat_5.GetComponent<StatusBattle>();
        speeds[3] = alpaca_6.GetComponent<StatusBattle>();
        speeds[4] = enemy_7.GetComponent<StatusBattle>();

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                sums[i] += speeds[i].playerStatusForReference.Speed_access;
                if (sums[i] > 1000)
                {
                    sums[i] = sums[i] % 1000;
                    return speeds[i].characterType;
                }
            }
        }
    }
}
