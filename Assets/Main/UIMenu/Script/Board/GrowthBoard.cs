using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthBoard : Board
{
    [SerializeField] protected GameObject CharacterHouse;

    protected FadeoutCharacterController fadeoutCharacterController;
    public void onButtonPush()
    {
        StartCoroutine(waitGrowthAnimation());
    }

    private IEnumerator waitGrowthAnimation()
    {
        Outlet outlet = CharacterHouse.GetComponent<Outlet>();
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

    }

    virtual public void childTakeEffect()
    {

    }
}
