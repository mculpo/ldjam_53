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

    public void loadScene(string NameScene)
    {
        StartCoroutine(onLoadScene(NameScene));
    }

    public void loadSceneAndDelete(string NameScene, GameObject delete)
    {
        Destroy(delete);
        StartCoroutine(onLoadScene(NameScene));
    }

    public IEnumerator onLoadScene(string NameScene)
    {
        yield return StartCoroutine(FadeController.instance.FadeInCoroutine());
        SceneManager.LoadScene(NameScene);
    }

    public void onCLickQuit()
    {
        Application.Quit();
    }
}
