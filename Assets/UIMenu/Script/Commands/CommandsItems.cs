using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandsItems : MonoBehaviour
{
    public GameObject myCommandList;
    public GameObject itemPrefab;
    [SerializeField] private GameObject board;
    private void OnEnable()
    {
        CommandList commandList = myCommandList.GetComponent<CommandList>();
        foreach (Command i in commandList.Commands)
        {
            itemPrefab.GetComponent<CommandFunctions>().nameText = i.command.name;
            itemPrefab.GetComponent<CommandFunctions>().costText = i.command.cost;
            GameObject instantiated = Instantiate(itemPrefab, this.transform);
            instantiated.GetComponent<Button>().onClick.AddListener(() => { board.GetComponent<Board>().updateText(i.command.description); });

        }
    }

    private void OnDisable()
    {
        foreach (Transform n in this.gameObject.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            //Command item = new Command("おもちアタック", 15);
            //myInventory.Add(item);
        }
        if (Input.GetKey(KeyCode.K))
        {
            //myInventory.Clear();
        }
    }
}
