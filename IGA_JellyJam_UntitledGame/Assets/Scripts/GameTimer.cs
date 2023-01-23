using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will act as a timer tthat when finished, the game will end.
/// </summary>
public class GameTimer : MonoBehaviour
{
    public PlayerController playerController;
    public RestartOnDeath restartOnDeath;
    public Light myLight;
    public GameObject endScreen;

    [SerializeField] private float gameTimeDurationInMinutes;
    [SerializeField] private float currentTime;
    public float intensitySpeed = 0.0125f;
    private float gameTimeDurationInSeconds;
    private float halfwayTimeInSeconds;

    private bool lightIncreasing;
    private bool timeReachedHalf;
    private bool timeReachedEnd;

    private void Awake()
    {
        myLight = GetComponent<Light>();

        gameTimeDurationInSeconds = gameTimeDurationInMinutes * 60f;
        halfwayTimeInSeconds = gameTimeDurationInSeconds / 2f;
        
        lightIncreasing = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lightIncreasing)
        {
            IncreaseLightIntensity();
        }
        
        else if(!lightIncreasing)
        {
            DecreaseLightIntensity();
        }

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

    private void IncreaseLightIntensity()
    {
        myLight.intensity += 0.3f * Time.deltaTime * intensitySpeed;
        if(myLight.intensity >= 1.6f)
        {
            lightIncreasing = false;
        }
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= 0.3f * Time.deltaTime * intensitySpeed;
    }

    // Placeholder to trigger game ending when time runs out
    private void GameHalfwayTrigger()
    {

    }

    // Placeholder to trigger game ending when time runs out
    private void GameEndsTrigger()
    {
        playerController.enabled = false;
        FindObjectOfType<AudioManager>().StopAllAudio();
        endScreen.SetActive(true);
        FindObjectOfType<AudioManager>().PlayOneShot("Restore");
        
    }
}
