using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float totalLevelTime;
    [SerializeField]
    private float currentlLevelTime;

    [SerializeField]
    private float startingGameTime = 10f;
    [SerializeField]
    private float currentGameTime = 0f;
    [SerializeField] 
    private Text countdownText;
    [SerializeField]
    private bool timeOver = false;
    [SerializeField]
    private event Action<float> AddTime;
    [SerializeField]
    private event Action<float> RemoveTime;

    // Start is called before the first frame update
    void Start()
    {
        loadScene();
        currentlLevelTime = totalLevelTime;
    }

    void Update()
    {
        currentlLevelTime -= Time.deltaTime;
        Console.WriteLine(currentlLevelTime);

        timeCount();
    }

    public void loadScene()
    {
        currentGameTime = startingGameTime;
    }

    public void refreshScreen()
    {
        int minutes = Mathf.FloorToInt(currentGameTime / 60);
        int seconds = Mathf.FloorToInt(currentGameTime % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void timeCount()
    {
        timeOver = false;

        if (!timeOver && currentGameTime > 0)
        {
            currentGameTime -= 1 * Time.deltaTime;
            refreshScreen();

            if (currentGameTime <= 0)
            {
                countdownText.text = "00:00";
                timeOver = true;
            }
        }
    }

    public void increaseCurrentGameTime(float seconds)
    {
        currentGameTime += seconds;
    }

    public void decreaseCurrentGameTime(float seconds)
    {
        currentGameTime -= seconds;
    }

    public void OnObjectivePicked()
    {
        if (AddTime != null)
        {
            AddTime(10f);
        }
    }

    public void OnObjectiveFailed()
    {
        if (RemoveTime != null)
        { 
            RemoveTime(10f); 
        }
    }

    public void increaseCurrentlLevelTime(float seconds)
    {
        currentlLevelTime += seconds;
    }

    public void decreaseCurrentlLevelTime(float seconds)
    {
        currentlLevelTime -= seconds;
    }

    public float TotalLevelTime { get => totalLevelTime; set => totalLevelTime = value; }
    public float CurrentlLevelTime { get => currentlLevelTime; set => currentlLevelTime = value; }
}
