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
        itemPrefab.GetComponent<ItemFunctions>().nameText = "おもち";
        itemPrefab.GetComponent<ItemFunctions>().countText = 5;
        Instantiate(itemPrefab,this.transform);
        Debug.Log("aaaasss");

        foreach (Item i in myInventory.Items)
        {
            itemPrefab.GetComponent<ItemFunctions>().name = i.nameItem;
            itemPrefab.GetComponent<ItemFunctions>().countText = i.count;
            Instantiate(itemPrefab);
            Debug.Log("aaaasss");
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
            Item item = new Item("おもち", 3);
            Debug.Log(item.nameItem);
            myInventory.Items.Add(item);
            Debug.Log("instantiated omochi");
        }
    }
}
