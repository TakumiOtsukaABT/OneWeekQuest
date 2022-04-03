using System.Collections;
using System.Collections.Generic;
using System;
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

    //select target
    [ReadOnly] public SelectingType selectingType = SelectingType.Disable;
    [SerializeField, ReadOnly] private List<GameObject> targetted = new List<GameObject>();


    [SerializeField, ReadOnly] private GameObject single_target;
    [SerializeField, ReadOnly] private bool selected = false;
    public GameObject Single_target { get => single_target; set => single_target = value; }


    private int[] sums = { 0, 0, 0, 0, 0 };

    void initializeProperty()
    {
        single_target = null;
        targetted.Clear();
        selected = false;
    }

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

    public void resetState(BattleState newState, bool nextTurn = true, GameObject battleEffect = null, bool multiple = false)
    {
        StartCoroutine(deactivate_then_activate_state(newState,nextTurn, battleEffect,multiple));
    }

    public void deactivateAllCanvas()
    {
        battleGameCanvasController_0.deactivateAll();
    }

    IEnumerator deactivate_then_activate_state(BattleState newState, bool nextTurn = true, GameObject battleEffect = null, bool multiple = false)
    {
        selectingType = SelectingType.Disable;
        battleGameCanvasController_0.deactivateAll();
        yield return new WaitForSeconds(0.5f);
        if (battleEffect != null)
        {
            if (!multiple)
            {
                GameObject effect = Instantiate(battleEffect);
                effect.transform.parent = single_target.transform;
                effect.transform.localPosition = new Vector3(0, 0, 0);
                effect.transform.localScale = new Vector3(5, 5, 5);
                effect.GetComponent<SpriteRenderer>().sortingOrder = 10;
            } else
            {
                foreach(var i in targetted)
                {
                    GameObject effect = Instantiate(battleEffect);
                    effect.transform.parent = i.transform;
                    effect.transform.localPosition = new Vector3(0, 0, 0);
                    effect.transform.localScale = new Vector3(5, 5, 5);
                    effect.GetComponent<SpriteRenderer>().sortingOrder = 10;
                }
            }
        }
        setState(newState,nextTurn);
        if (turn_queue.Count < 10)
        {
            turn_queue.Enqueue(GetNextEnque());
        }
        initializeProperty();
    }


    private void setState(BattleState newState, bool nextTurn=true)
    {
        battleState = newState;
        switch (newState)
        {
            case BattleState.WaitingInput:
                Debug.Log("waiting input");
                if (nextTurn)
                {
                    currentCharacter = turn_queue.Dequeue();
                }
                
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
                initializeProperty();
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

    public GameObject getCurrentCharacter()
    {
        return getCharacterObject(currentCharacter);
    }

    public GameObject getCharacterObject(characterType character)
    {
        switch (character)
        {
            case characterType.Human:
                return human_3;
            case characterType.Dog:
                return dog_4;
            case characterType.Cat:
                return cat_5;
            case characterType.Alpaca:
                return alpaca_6;
            case characterType.Enemy:
                return enemy_7;
            default:
                return human_3;
        }
    }


    public void setTakeDamageAndDialogue(int damage){
        Event _event = new Event();
        if (single_target.GetComponent<StatusBattle>().barrier)
        {
            damage = 0;
        }
        single_target.GetComponent<StatusBattle>().takeDamage(damage);
        _event.nextState = BattleState.WaitingInput;
        _event.dialogue = new string[2];
        _event.dialogue[1] = "";
        _event.dialogue[0] = single_target.GetComponent<StatusBattle>().name + "に" + damage.ToString() + "のダメージ!";
        battleGameCanvasController_0.setDescriptionByEvent(_event);
    }

    public void setBarrierAndDialogue()
    {
        Event _event = new Event();
        single_target.GetComponent<StatusBattle>().setBarrier(true);
        _event.nextState = BattleState.WaitingInput;
        _event.dialogue = new string[2];
        _event.dialogue[1] = "";
        _event.dialogue[0] = single_target.GetComponent<StatusBattle>().name + "にバリアを付与した!";
        battleGameCanvasController_0.setDescriptionByEvent(_event);
    }

    public void setBarriersAndDialogue()
    {
        Event _event = new Event();
        _event.dialogue = new string[targetted.Count+1];
        for(int i =0;i<targetted.Count;i++)
        {
            targetted[i].GetComponent<StatusBattle>().setBarrier(true);
            _event.dialogue[i] = targetted[i].GetComponent<StatusBattle>().name + "にバリアを付与した!";
        }
        _event.nextState = BattleState.WaitingInput;
        _event.dialogue[targetted.Count] = "";

        battleGameCanvasController_0.setDescriptionByEvent(_event);
    }
    public void setClickedObject(GameObject gameObject)
    {
        switch (selectingType)
        {
            case SelectingType.Single:
                Single_target = gameObject;
                battleGameCanvasController_0.updateDescription_singleTarget(Single_target.GetComponent<StatusBattle>().characterType);
                break;
            case SelectingType.Multiple:
                for (int i = 0; i < targetted.Count; i++)
                {
                    if (gameObject.Equals(targetted[i]))
                    {
                        targetted.Remove(gameObject);
                        return;
                    }
                }
                targetted.Add(gameObject);
                break;
            case SelectingType.Disable:
                break;
        }
        return;
    }

    public bool getFlagDoneSelecting()
    {
        if (Single_target != null || targetted != null)
        {
            return selected;
        }
        else { return false; }
    }

    public void setSelectedFlag()
    {
        selected = true;
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
