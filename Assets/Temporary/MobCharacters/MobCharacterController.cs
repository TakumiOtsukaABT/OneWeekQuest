using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCharacterController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.Find("Canvas").gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
    }
}
