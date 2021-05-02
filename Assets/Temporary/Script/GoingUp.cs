using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoingUp : MonoBehaviour
{
    public void Onclick()
    {
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
