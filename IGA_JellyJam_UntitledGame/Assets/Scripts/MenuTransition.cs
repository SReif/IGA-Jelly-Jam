using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{
    public GameObject mainCamera;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioClip = mainCamera.GetComponent<AudioSource>().clip;
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
        //AudioManager.Instance.Stop("Background Music");
        this.gameObject.SetActive(true);
        mainCamera.GetComponent<AudioSource>().Stop();
        Time.timeScale = 0;
    }

    //Disables Main Menu
    private void DisableMainMenu()
    {
        
        mainCamera.GetComponent<AudioSource>().PlayOneShot(audioClip);
        //AudioManager.Instance.Play("Background Music");
        this.gameObject.SetActive(false);
    }
}
