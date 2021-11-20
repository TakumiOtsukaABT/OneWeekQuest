using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandContent : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject battleCommandPrefab;
    [SerializeField] private GameObject board;
    [SerializeField] private BattleCommandReference battleCommandReference;
    private Outlet outlet;
    private void OnEnable()
    {
        outlet = menuCanvas.GetComponent<Outlet>();
        List<int> battle_commands_id_list = outlet.gameObjects[0].GetComponent<PlayerBattleCommandList>().IdList;
        foreach (int i in battle_commands_id_list)
        {
            battleCommandPrefab.GetComponent<BattleCommandPrefabSetter>().nameText = battleCommandReference.GetElement(i).element_name;
            battleCommandPrefab.GetComponent<BattleCommandPrefabSetter>().costText = battleCommandReference.GetElement(i).cost;
            GameObject instantiated = Instantiate(battleCommandPrefab, this.transform);
            instantiated.GetComponent<Button>().onClick.AddListener(() => { board.GetComponent<Board>().updateText(battleCommandReference.GetElement(i).description); });

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
