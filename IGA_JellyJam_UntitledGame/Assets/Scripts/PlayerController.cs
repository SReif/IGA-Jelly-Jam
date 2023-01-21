using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    public float upwardSpeed;
    public float downwardSpeed;

    public RestartOnDeath restartOnDeath;

    private Vector3 playerStart;
    private Vector3 cameraStart;

    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        cameraStart = GameObject.Find("Main Camera").GetComponent<Transform>().position;
        restartOnDeath = GetComponent<RestartOnDeath>();

        playerStart = this.transform.position;

        playerAnimator = gameObject.GetComponent<Animator>();

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
            restartOnDeath.PlayerDeath(playerStart, cameraStart);
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
        playerAnimator.SetTrigger("Flap");
    }

    //Causes player to move forward and fall
    private void PlayerScroll()
    {
        transform.Translate(Vector3.down * Time.deltaTime * downwardSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * forwardSpeed);
    }
}
