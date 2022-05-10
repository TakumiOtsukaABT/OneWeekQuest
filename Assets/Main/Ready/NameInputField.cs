using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameInputField : MonoBehaviour
{
    public void onClickConfirm()
    {

        SceneManager.LoadScene("Town");
    }
}
