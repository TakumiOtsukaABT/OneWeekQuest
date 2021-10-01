using UnityEngine;


public class GoingUp : MonoBehaviour
{

    public string nextPositionName = "";
    public string nextFloorName = "";
    public string stairPositionClassName = "";

    public void Onclick()
    {
        //GameObject.Find("Character").transform.position = transform.parent.Find(stairPositionClassName).transform.position;
        transform.root.gameObject.GetComponent<FloorController>().moveFloorUp(nextPositionName, nextFloorName);

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
