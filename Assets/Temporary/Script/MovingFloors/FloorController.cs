﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public float leftLim, rightLim;
    private Floor ActiveFloor;
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        ActiveFloor = transform.GetChild(0).GetComponent<Floor>();
        character = GameObject.Find("Character");
        updateparams();
    }

    void updateparams()
    {
        this.leftLim = ActiveFloor.LeftLim;
        this.rightLim = ActiveFloor.RightLim;
    }

    private IEnumerator waitUpStairAnimation(string positionName, string floorName)
    {
        character.GetComponent<AnimationHandle>().animationUpStairs();

        yield return new WaitForSeconds(character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length/0.5f +1.0f);
        ActiveFloor = GameObject.Find(floorName).GetComponent<Floor>();
        character.transform.position = ActiveFloor.transform.Find(positionName).transform.position;
        updateparams();
        var camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        camera.setHaji(ActiveFloor);
        yield return new WaitUntil(camera.resetCameraPosition);
    }

    public void moveFloor(string positionName, string floorName)
    {
        StartCoroutine(waitUpStairAnimation(positionName, floorName));
    }
}
