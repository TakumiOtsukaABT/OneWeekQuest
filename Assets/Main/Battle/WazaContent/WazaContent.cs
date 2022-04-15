using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WazaContent : MonoBehaviour
{
    public List<GameObject> techniquePrefabs =  new List<GameObject>();
    void OnEnable()
    {
        //outlet = menuCanvas.GetComponent<Outlet>();
        //List<int> commands_id_list = outlet.gameObjects[0].GetComponent<CommandList>().IdList;
        //foreach (int i in commands_id_list)
        //{
        //    setPrefab(i);
        //    GameObject instantiated = Instantiate(prefab, this.transform);
        //    instantiated.GetComponent<Button>().onClick.AddListener(() => {
        //        setListener(i);
        //    });
        //}
    }
}
