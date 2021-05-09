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

    private IEnumerator Inoperable(float i) // 操作を不能にする（引数の秒数間）
    {
        GameObject inputObj = GameObject.Find("Character");
        CharacterController inputScript = inputObj.GetComponent<CharacterController>();
        inputScript.InputBoolean = false; // スクリプトを無効化
        yield return new WaitForSeconds(i); // 引数の秒数だけ待つ
        inputScript.InputBoolean = true; // スクリプトを有効化
        yield break;
    }

    public void CallInoperable(float i)
    {
        StartCoroutine("Inoperable", i); // 他のスクリプトから呼び出す用
    }

    private IEnumerator waitUpStairAnimation(string FloorName)
    {
        character.GetComponent<AnimationHandle>().animationUpStairs();
        yield return new WaitForSeconds(character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length/0.5f +1.0f);
        character.transform.position = GameObject.Find(FloorName).transform.Find("FloorStartPosition").transform.position;
    }

    public void moveFloor(string FloorName)
    {
        StartCoroutine(waitUpStairAnimation(FloorName));
    }
}
