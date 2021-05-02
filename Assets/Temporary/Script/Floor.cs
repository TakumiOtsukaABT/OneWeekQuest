using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] 
    private float rightLim;
    [SerializeField]
    private float leftLim;

    public float LeftLim { get => leftLim; set => leftLim = value; }
    public float RightLim { get => rightLim; set => rightLim = value; }
}
