using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandsItems : MonoBehaviour
{
    public BaseCommands myInventory;
    public GameObject itemPrefab;
    private void OnEnable()
    {
        Debug.Log("tttt" + myInventory.Commands.Count);
        foreach (Command i in myInventory.Commands)
        {
            itemPrefab.GetComponent<CommandFunctions>().nameText = i.nameItem;
            itemPrefab.GetComponent<CommandFunctions>().costText = i.cost;
            Instantiate(itemPrefab, this.transform);
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
            Command item = new Command("おもちアタック", 15);
            myInventory.Add(item);
        }
        if (Input.GetKey(KeyCode.K))
        {
            myInventory.Clear();
        }
    }
}
