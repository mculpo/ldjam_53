using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void onCLickJogar()
    {
        SceneManager.LoadScene(0);
    }

    public void onCLickQuit()
    {
        Application.Quit();
    }
}
