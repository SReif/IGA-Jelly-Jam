using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnDeath : MonoBehaviour
{
    public MenuTransition menuTransition;
    public CameraFollow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Sets player back to start and enables main menu
    public void PlayerDeath(Vector3 playerStart, Vector3 cameraStart)
    {
        transform.position = playerStart;
        cameraFollow.transform.position = cameraStart;
        menuTransition.EnableMainMenu();
    }
}
