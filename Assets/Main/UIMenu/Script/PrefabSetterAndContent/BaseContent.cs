using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseContent <U,CommandReference,CommandList> : MonoBehaviour 
    where U:BaseItemType
    where CommandReference : BaseReference<U>
    where CommandList: BasePlayerData
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] protected GameObject prefab;
    [SerializeField] private GameObject board;
    [SerializeField] protected CommandReference battleCommandReference;
    private Outlet outlet;
    private void OnEnable()
    {
        outlet = menuCanvas.GetComponent<Outlet>();
        List<int> commands_id_list = outlet.gameObjects[0].GetComponent<CommandList>().IdList;
        foreach (int i in commands_id_list)
        {
            setPrefab(i);
            GameObject instantiated = Instantiate(prefab, this.transform);
            instantiated.GetComponent<Button>().onClick.AddListener(() => { board.GetComponent<Board>().updateText(battleCommandReference.GetElement(i).description); });

        }
    }
    protected virtual void setPrefab(int i)
    {

    }

    private void OnDisable()
    {
        foreach (Transform n in this.gameObject.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
}