using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject description;

    public void updateText(string newText)
    {
        description.GetComponent<TextMeshPro>().text = newText;
    }
}
