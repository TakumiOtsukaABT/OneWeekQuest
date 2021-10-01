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
        Inventory inventory = myInventory.GetComponent<Inventory>();

        foreach (Item i in inventory.Items)
        {
            itemPrefab.GetComponent<ItemFunctions>().nameText = i.itemDescription.name;
            itemPrefab.GetComponent<ItemFunctions>().countText = i.count;
            GameObject instantiated = Instantiate(itemPrefab, this.transform);
            instantiated.GetComponent<Button>().onClick.AddListener(() => {
                board.GetComponent<Board>().updateText(i.itemDescription.description);
            });
        }
    }

    private void OnDisable()
    {
        foreach (Transform n in this.gameObject.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
}
