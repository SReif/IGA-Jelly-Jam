using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorableEntity : MonoBehaviour
{
    [SerializeField] private Material materialDecay;
    [SerializeField] private Material materialRestore;

    private bool restored;

    public void TurnFromDecayToRestore()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = materialRestore;
        
        if(!restored)
        {
            FindObjectOfType<AudioManager>().PlayOneShot("Restore");
            restored = true;
        }
    }

    public void TurnFromRestoreToDecay()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = materialDecay;
        restored = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        restored = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
