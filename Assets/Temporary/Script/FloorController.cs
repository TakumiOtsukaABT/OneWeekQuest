using System.Collections;
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

    private IEnumerator waitUpStairAnimation(string FloorName)
    {
        character.GetComponent<AnimationHandle>().animationUpStairs();
        yield return new WaitForSeconds(character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length/0.5f +1.0f);
        character.transform.position = GameObject.Find(FloorName).transform.Find("FloorStartPosition").transform.position;
        yield return new WaitUntil(GameObject.Find("Main Camera").GetComponent<CameraFollow>().resetCameraPosition);
    }

    public void moveFloor(string FloorName)
    {
        StartCoroutine(waitUpStairAnimation(FloorName));
    }
}
