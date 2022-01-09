using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthBoard : Board
{
    [SerializeField] protected GameObject CharacterHouse;
    [SerializeField] protected TaskHandler taskHandler_3;
    Outlet outlet;

    protected FadeoutCharacterController fadeoutCharacterController;
    public void onButtonPush()
    {
        StartCoroutine(waitGrowthAnimation());
    }

    private void Start()
    {
        outlet = CharacterHouse.GetComponent<Outlet>();
        taskHandler_3 = outlet.gameObjects[3].GetComponent<TaskHandler>();
    }

    private IEnumerator waitGrowthAnimation()
    {
        
        BlackoutController blackout = outlet.gameObjects[1].GetComponent<BlackoutController>();
        fadeoutCharacterController = outlet.gameObjects[2].GetComponent<FadeoutCharacterController>();
        blackout.ActivateFadeout();
        childActivation();
        childTakeEffect();
        yield return new WaitForSeconds(3);
        blackout.DeactivateFadeoutWithDelay(0);
        childDeactivation();
    }

    virtual public void childActivation()
    {

    }

    virtual public void childDeactivation()
    {
        fadeoutCharacterController.DeactivateWithDelay(0);
        CharacterHouse.GetComponent<MenuCanvas>().popWindow();
        CharacterHouse.GetComponent<MenuCanvas>().popWindowForCharacterHouse();
    }

    virtual public void childTakeEffect()
    {

    }
}
