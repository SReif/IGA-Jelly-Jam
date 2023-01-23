using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{
    public GameObject mainCamera;
    public AudioClip[] audioSource;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu Loop");
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
            DisableMainMenu();
        }
    }

    //Enables Main Menu
    public void EnableMainMenu()
    {
        this.gameObject.SetActive(true);
        //FindObjectOfType<AudioManager>().Stop("Background");
        FindObjectOfType<AudioManager>().Play("Menu Loop");
        Time.timeScale = 0;
    }

    //Disables Main Menu
    private void DisableMainMenu()
    {
        FindObjectOfType<AudioManager>().Stop("Menu Loop");
        FindObjectOfType<AudioManager>().Play("Background");
        this.gameObject.SetActive(false);
    }
}
