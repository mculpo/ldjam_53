using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
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
