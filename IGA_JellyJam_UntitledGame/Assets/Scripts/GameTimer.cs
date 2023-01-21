using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will act as a timer tthat when finished, the game will end.
/// </summary>
public class GameTimer : MonoBehaviour
{

    [SerializeField] private float gameTimeDurationInMinutes;

    private float gameTimeDurationInSeconds;
    private float halfwayTimeInSeconds;
    private float currentTime;

    private bool timeReachedHalf;
    private bool timeReachedEnd;

    private void Awake()
    {
        gameTimeDurationInSeconds = gameTimeDurationInMinutes * 60f;
        halfwayTimeInSeconds = gameTimeDurationInSeconds / 2f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerTracker();
    }

    private void TimerTracker()
    {
        currentTime += Time.deltaTime;
        if (!timeReachedHalf && currentTime >= halfwayTimeInSeconds)
        {
            GameHalfwayTrigger();
            timeReachedHalf = true;
        }
        if (!timeReachedEnd && currentTime >= gameTimeDurationInSeconds)
        {
            GameEndsTrigger();
            timeReachedEnd = true;
        }

    }

    // Placeholder to trigger game ending when time runs out
    private void GameHalfwayTrigger()
    {

    }

    // Placeholder to trigger game ending when time runs out
    private void GameEndsTrigger()
    {

    }
}
