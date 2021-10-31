using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHouseController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.Find("growth_hukidashi").gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.transform.Find("growth_hukidashi").gameObject.SetActive(false);
    }
}
