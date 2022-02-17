using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDayButton : MonoBehaviour
{
    public GameObject Menu;
    private Outlet outlet;
    [SerializeField,ReadOnly] private FadeoutCharacterController fadeoutCharacterController_1;
    [SerializeField, ReadOnly] private BlackoutController blackout_2;
    [SerializeField, ReadOnly] private TaskHandler taskHandler_3;
    [SerializeField, ReadOnly] private AlertScript alertScript_4;
    public void onButtonClick(string sceneName)
    {
        outlet = Menu.GetComponent<Outlet>();
        fadeoutCharacterController_1 = outlet.gameObjects[1].GetComponent<FadeoutCharacterController>();
        blackout_2 = outlet.gameObjects[2].GetComponent<BlackoutController>();
        taskHandler_3 = outlet.gameObjects[3].GetComponent<TaskHandler>();
        alertScript_4 = outlet.gameObjects[4].GetComponent<AlertScript>();
        if (taskHandler_3.isAllTicked())
        {
            StartCoroutine(waitAndLoadScene(sceneName));
        }
        else
        {
            alertScript_4.Activate("タスクが終わっていません",0);
        }
    }

    IEnumerator waitAndLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(0.3f);
        blackout_2.ActivateFadeout();
        fadeoutCharacterController_1.ActivateSleep();
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneName);
    }
}
