using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    void Start()
    {
        //AudioManager.Instance.Play("Intro Music");
        Debug.Log("Playing music");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //AudioManager.Instance.Stop("Intro Music");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        //AudioManager.Instance.Play("Intro Music");
    }
}
