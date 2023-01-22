using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
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
        audioManager.Stop("Background Music");
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    //Disables Main Menu
    private void DisableMainMenu()
    {
        audioManager.Play("Background Music");
        this.gameObject.SetActive(false);
    }
}
