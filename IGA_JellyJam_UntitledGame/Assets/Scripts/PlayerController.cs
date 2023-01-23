using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    public float upwardSpeed;
    public float downwardSpeed;

    private bool isFlapping;

    public RestartOnDeath restartOnDeath;

    public Vector3 playerStart;
    public Vector3 cameraStart;

    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        cameraStart = GameObject.Find("Main Camera").GetComponent<Transform>().position;
        restartOnDeath = GetComponent<RestartOnDeath>();

        playerStart = this.transform.position;

        playerAnimator = gameObject.GetComponent<Animator>();
        isFlapping = false;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerScroll();
        
        if(Input.GetKey(KeyCode.Space))
        {
            PlayerFly();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Stop("Flap");
            isFlapping = false;
        }
    }

private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.ToString());
        // Game over if touching ground
        if (other.tag == "Ground")
        {
            FindObjectOfType<AudioManager>().PlayOneShot("Death");
            FindObjectOfType<AudioManager>().Stop("Background");
            StartCoroutine(Delay(3f));
            this.GetComponent<PlayerController>().enabled = false;
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
        if(!isFlapping)
        {
            FindObjectOfType<AudioManager>().Play("Flap");
            isFlapping = true;
        }
        
    }

    //Causes player to move forward and fall
    private void PlayerScroll()
    {
        transform.Translate(Vector3.down * Time.deltaTime * downwardSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * forwardSpeed);
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        restartOnDeath.PlayerDeath(playerStart, cameraStart);
    }
}
