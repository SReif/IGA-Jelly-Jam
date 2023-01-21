using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{
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
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    //Disables Main Menu
    private void DisableMainMenu()
    {
        this.gameObject.SetActive(false);
    }
}
