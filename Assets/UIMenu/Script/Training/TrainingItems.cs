using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrainingItems : MonoBehaviour
{
    public GameObject myCommandList;
    public GameObject itemPrefab;
    private void OnEnable()
    {
        TrainingList commandList = myCommandList.GetComponent<TrainingList>();
        foreach (TrainingCommand i in commandList.Commands)
        {
            itemPrefab.GetComponent<CommandFunctions>().nameText = i.trainingCommand.name;
            GameObject instantiated = Instantiate(itemPrefab, this.transform);
            instantiated.GetComponent<Button>().onClick.AddListener(() => { this.animate(); });

        }
    }

    private void animate()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        foreach (Transform n in this.gameObject.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
}
