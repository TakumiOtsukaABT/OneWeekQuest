using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using Gamekit2D;

public class GameDirector : MonoBehaviour
{
    private Queue<characterType> turn_queue = new Queue<characterType>();
    [SerializeField, ReadOnly] private BattleState battleState = BattleState.Read;
    [SerializeField, ReadOnly] private InputControllerForBattle inputController_2;
    [SerializeField, ReadOnly] private BattleGameCanvasController battleGameCanvasController_0;
    public List<GameObject> activeCharacters = new List<GameObject>();

    [SerializeField, ReadOnly] private GameObject human_3;
    public GameObject Human { get => human_3; }
    [SerializeField, ReadOnly] private GameObject dog_4;
    public GameObject Dog { get => dog_4; }
    [SerializeField, ReadOnly] private GameObject cat_5;
    public GameObject Cat { get => cat_5; }
    [SerializeField, ReadOnly] private GameObject alpaca_6;
    public GameObject Alpaca { get => alpaca_6; }
    [SerializeField, ReadOnly] private GameObject enemy_7;
    public GameObject Enemy { get => enemy_7; }

    [SerializeField, ReadOnly] private characterType currentCharacter;

    //select target
    [ReadOnly] public SelectingType selectingType = SelectingType.Disable;
    [SerializeField, ReadOnly] public List<GameObject> targetted = new List<GameObject>();


    [SerializeField, ReadOnly] private GameObject single_target;
    [SerializeField, ReadOnly] private bool selected = false;
    public GameObject Single_target { get => single_target; set => single_target = value; }
    public bool IsReviveCalling { get => isReviveCalling; set => isReviveCalling = value; }
    public string[] loseString;
    public string[] winString;
    private bool isReviveCalling;

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
        if (Human.activeSelf) activeCharacters.Add(Human);
        if (Dog.activeSelf) activeCharacters.Add(Dog);
        if (Cat.activeSelf) activeCharacters.Add(Cat);
        if (Alpaca.activeSelf) activeCharacters.Add(Alpaca);
        initQueue();
    }

    // Update is called once per frame

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


        Debug.Log("win "+win().ToString());
        Debug.Log("st lose "+ lose().ToString());


        if (!win() && !lose())
        {
            setState(newState, nextTurn);
        } else if(win())
        {
            goToWin();
        } else if (lose())
        {
            goToLose();
        }


        if (turn_queue.Count < 10)
        {
            turn_queue.Enqueue(GetNextEnque());
        }
        initializeProperty();
    }

    private void goToLose()
    {
        addDialogue(loseString);
        setState(BattleState.Read);
    }

    private void goToWin()
    {
        addDialogue(winString);
        setState(BattleState.Read);
    }

    private void setState(BattleState newState, bool nextTurn=true)
    {
        battleState = newState;
        switch (newState)
        {
            case BattleState.WaitingInput:
                if (nextTurn)
                {
                    int i = 0;
                    while (i < 10)
                    {
                        if (getCharacterObject(turn_queue.Peek()).GetComponent<StatusBattle>().getAlive())
                        {
                            currentCharacter = turn_queue.Dequeue();
                            if (currentCharacter.Equals(characterType.Enemy))
                            {
                                Debug.Log("haitteru?");
                                var enemy = getCharacterObject(currentCharacter);
                                enemy.GetComponent<EnemyPattern>().runPatternedBattleCommand();
                                break;
                            }
                            getCurrentCharacter().GetComponent<StatusBattle>().setMP(
    getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.MP_access +
    getCurrentCharacter().GetComponent<StatusBattle>().playerStatusForReference.Regen_access
    );
                            battleGameCanvasController_0.atWaitingInput(currentCharacter);
                            inputController_2.setInputHandle<Battle_CommandInputHandle>();
                            break;
                        }
                        else
                        {
                            turn_queue.Dequeue();
                            if (turn_queue.Count < 10)
                            {
                                turn_queue.Enqueue(GetNextEnque());
                            }
                        }
                        i++;
                    }
                }
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

    public void setDialogue(string[] dialogues)
    {
        var dialist = dialogues.ToList();
        dialist.Add("");
        Event _event = new Event();
        _event.nextState = BattleState.WaitingInput;
        _event.dialogue = dialist.ToArray();
        Debug.Log(_event.dialogue[0]);
        Debug.Log(dialogues[0]);
        battleGameCanvasController_0.setDescriptionByEvent(_event);
    }

    private void addDialogue(string[] dialogues)
    {
        var dialist = dialogues.ToList();
        dialist.Add("");
        Event _event = new Event();
        _event.nextState = BattleState.WaitingInput;
        _event.dialogue = dialist.ToArray();
        Debug.Log(_event.dialogue[0]);
        Debug.Log(dialogues[0]);
        battleGameCanvasController_0.addDescriptionByEvent(_event);
    }


    public string setTakeDamageAndDialogue(int damage){
        Event _event = new Event();
        if (single_target.GetComponent<StatusBattle>().barrier)
        {
            damage = 0;
            single_target.GetComponent<StatusBattle>().barrier = false;
        }
        single_target.GetComponent<StatusBattle>().takeDamage(damage);
        _event.nextState = BattleState.WaitingInput;
        _event.dialogue = new string[2];
        _event.dialogue[1] = "";
        _event.dialogue[0] = single_target.GetComponent<StatusBattle>().name + "に" + damage.ToString() + "のダメージ!";
        battleGameCanvasController_0.setDescriptionByEvent(_event);
        return _event.dialogue[0];
    }

    public void setHealAndDialogue(int healAmount)
    {
        Event _event = new Event();
        if (single_target.GetComponent<StatusBattle>().barrier)
        {
            healAmount = 0;
            single_target.GetComponent<StatusBattle>().barrier = false;
        }
        single_target.GetComponent<StatusBattle>().heal(healAmount);
        _event.nextState = BattleState.WaitingInput;
        _event.dialogue = new string[2];
        _event.dialogue[1] = "";
        _event.dialogue[0] = single_target.GetComponent<StatusBattle>().name + "に" + healAmount.ToString() + "の回復!";
        battleGameCanvasController_0.setDescriptionByEvent(_event);
    }

    public void setReviveAndDialogue()
    {
        Event _event = new Event();
        _event.dialogue = new string[2];

        if (single_target.GetComponent<StatusBattle>().getAlive())
        {
            _event.dialogue[0] = single_target.GetComponent<StatusBattle>().name + "は生きている!";
        } else
        {
            _event.dialogue[0] = single_target.GetComponent<StatusBattle>().name + "は復活した!";
            single_target.GetComponent<StatusBattle>().heal(100);
        }
        single_target.GetComponent<StatusBattle>().setAlive(true);
        _event.dialogue[1] = "";
        battleGameCanvasController_0.setDescriptionByEvent(_event);
    }

    public void setNoMPDialogue()
    {
        battleGameCanvasController_0.setNoMPDescription();
    }

    private void setNoAliveDialogue(characterType characterType)
    {
        battleGameCanvasController_0.setNoAliveDescription(characterType);
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
        if (gameObject.GetComponent<StatusBattle>().getAlive() || isReviveCalling)
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
                            updateDialogue_MultipleTargetted();
                            return;
                        }
                    }
                    targetted.Add(gameObject);
                    updateDialogue_MultipleTargetted();
                    break;
                case SelectingType.Disable:
                    break;
            }
        } else
        {
            setNoAliveDialogue(gameObject.GetComponent<StatusBattle>().characterType);
        }
        return;
    }

    private void updateDialogue_MultipleTargetted()
    {
        List<characterType> targettedCharacterType = new List<characterType>();
        foreach (var i in targetted)
        {
            targettedCharacterType.Add(i.GetComponent<StatusBattle>().characterType);
        }
        battleGameCanvasController_0.updateDescription_multipleTarget(targettedCharacterType.ToArray());
    }

    public bool getFlagDoneSelecting()
    {
            return selected;
    }

    public void setSelectedFlag()
    {
        if (Single_target != null || targetted.Count != 0)
        {
            selected = true;
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
                if (speeds[i].getAlive())
                {
                    sums[i] += speeds[i].playerStatusForReference.Speed_access;
                }
                if (sums[i] > 1000)
                {
                    sums[i] = sums[i] % 1000;
                    return speeds[i].characterType;
                }
            }
        }
    }

    public bool win()
    {
        return !enemy_7.GetComponent<StatusBattle>().getAlive();
    }

    public bool lose()
    {
        bool allDead = true;
        for (int i = 0; i < activeCharacters.Count; i++)
        {
            Debug.Log("1all dead " + allDead.ToString());

            if (activeCharacters[i].GetComponent<StatusBattle>().getAlive())
            {
                Debug.Log("aaaaaaa");
                allDead = false;
            }
            Debug.Log("2all dead " + allDead.ToString());

        }
        Debug.Log("3all dead " + allDead.ToString());

        return allDead;//hitori demo ikitetara false
    }
}
