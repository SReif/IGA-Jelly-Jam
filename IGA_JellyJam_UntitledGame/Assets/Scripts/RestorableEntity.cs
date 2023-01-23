using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorableEntity : MonoBehaviour
{
    [SerializeField] private Material materialDecay;
    [SerializeField] private Material materialRestore;

    public void TurnFromDecayToRestore()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = materialRestore;
    }

    public void TurnFromRestoreToDecay()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = materialDecay;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
