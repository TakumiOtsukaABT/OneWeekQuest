using UnityEngine;


public class GoingUp : MonoBehaviour
{

    public string nextPositionName = "";
    public string nextFloorName = "";

    public void Onclick()
    {
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
