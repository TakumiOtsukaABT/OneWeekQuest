﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoingUp : MonoBehaviour
{

    [SerializeField] string floorName;
    public string nextFloorName;
    public void Onclick()
    {
        GameObject.Find("Character").transform.position = transform.Find("StairPosition").transform.position;
        Debug.Log("tttt" + nextFloorName);
        transform.root.gameObject.GetComponent<FloorController>().moveFloor(nextFloorName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.Find("Canvas").gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
    }
}
