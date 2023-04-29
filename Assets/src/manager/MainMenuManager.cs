using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void onCLickJogar()
    {
        SceneManager.LoadScene(0);
    }

    public void onCLickQuit()
    {
        Application.Quit();
    }
}
