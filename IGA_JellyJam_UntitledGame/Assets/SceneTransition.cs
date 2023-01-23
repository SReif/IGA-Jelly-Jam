using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            FindObjectOfType<AudioManager>().Play("Intro");
        }
        
        Debug.Log("Playing music");
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Stop("Intro");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().StopAllAudio();
        FindObjectOfType<AudioManager>().Play("Intro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
