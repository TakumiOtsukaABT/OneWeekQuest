using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public BaseInventory myInventory;
    public GameObject itemPrefab;
    private void OnEnable()
    {
        Debug.Log("aaaa");

        foreach (Item i in myInventory.Items)
        {
            itemPrefab.transform.Find("name").GetComponent<Text>().text = i.nameItem;
            itemPrefab.transform.Find("count").GetComponent<Text>().text = i.count.ToString();
            Instantiate(itemPrefab);
            Debug.Log("aaaa");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            Item item = new Item("おもち", 3);
            myInventory.Items.Add(item);
            Debug.Log("instantiated omochi");
        }
    }
}
