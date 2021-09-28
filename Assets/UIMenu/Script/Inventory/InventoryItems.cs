using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public GameObject myInventory;
    public GameObject itemPrefab;
    [SerializeField] private GameObject board;

    private void OnEnable()
    {
        //foreach (Item i in myInventory.Items)
        //{
        //    itemPrefab.GetComponent<ItemFunctions>().nameText = i.nameItem;
        //    itemPrefab.GetComponent<ItemFunctions>().countText = i.count;
        //    GameObject instantiated = Instantiate(itemPrefab, this.transform);
        //    instantiated.GetComponent<Button>().onClick.AddListener(() => { board.GetComponent<Board>().updateText("aaaa"); });
        //}
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
            myInventory.Add(item);
        }
        if (Input.GetKey(KeyCode.K))
        {
            myInventory.Clear();
        }
    }
}
