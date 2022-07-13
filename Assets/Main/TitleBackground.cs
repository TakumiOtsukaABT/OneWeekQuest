using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackground : MonoBehaviour
{
    public float scrollSpeed;
    public Vector2 startPos;
    public float imageBound = 22.455f;
    public float newPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        newPos = Mathf.Repeat(newPos + scrollSpeed, imageBound);
        transform.position = startPos + Vector2.right * newPos;
    }

    //aaaaa
}
