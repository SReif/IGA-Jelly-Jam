using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    public float upwardSpeed;
    public float downwardSpeed;

    public MenuTransition menuTransition;
    public CameraFollow cameraFollow;

    private Vector3 playerStart;

    // Start is called before the first frame update
    void Start()
    {
        menuTransition = GameObject.Find("Main Menu").GetComponentInChildren<MenuTransition>();
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        playerStart = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScroll();
        
        if(Input.GetKey(KeyCode.Space))
        {
            PlayerFly();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.ToString());
        // Game over if touching ground
        if (other.tag == "Ground")
        {
            PlayerDeath();
        }
        // Turn something into a restorable
        if (other.tag == "Restorable")
        {
            var restoreEntity = other.gameObject.GetComponent<RestorableEntity>();
            Debug.Log(restoreEntity.ToString());
            restoreEntity.TurnFromDecayToRestore();
        }
    }

    //Causes player object to move up
    private void PlayerFly()
    {
        transform.Translate(Vector3.up * Time.deltaTime * upwardSpeed);
    }

    //Causes player to move forward and fall
    private void PlayerScroll()
    {
        transform.Translate(Vector3.down * Time.deltaTime * downwardSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * forwardSpeed);
    }

    //Sets player back to start and enables main menu
    private void PlayerDeath()
    {
        transform.position = playerStart;
        cameraFollow.transform.position = new Vector3(-9, 1, -20);
        menuTransition.EnableMainMenu();
    }
}
