using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthButtonEnabler : MonoBehaviour
{
    [SerializeField] TaskHandler taskHandler;
    [SerializeField] GameObject TrainingButton;
    [SerializeField] GameObject StudyButton;
    [SerializeField] GameObject EatButton;

    public void OnEnable()
    {
        if(!taskHandler.getBaseTaskByKey("Train").clearFlag)
        {
            TrainingButton.SetActive(true);
        }
        else
        {
            TrainingButton.SetActive(false);
        }

        if (!taskHandler.getBaseTaskByKey("Study").clearFlag)
        {
            StudyButton.SetActive(true);
        }
        else
        {
            StudyButton.SetActive(false);
        }

        if (!taskHandler.getBaseTaskByKey("Eat").clearFlag)
        {
            EatButton.SetActive(true);
        }
        else
        {
            EatButton.SetActive(false);
        }
    }
}
