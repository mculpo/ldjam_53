using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float totalLevelTime;
    [SerializeField]
    private float currentlLevelTime;

    // Start is called before the first frame update
    void Start()
    {
        currentlLevelTime = totalLevelTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentlLevelTime -= Time.deltaTime;
        Console.WriteLine(currentlLevelTime);
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
