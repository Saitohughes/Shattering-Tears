using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UManPlayerController : MonoBehaviour
{
    [SerializeField]
    float Score;
    Rigidbody[] _allrigidbodies;


    private void Awake()
    {
        _allrigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Rigidbody rb in _allrigidbodies)
        {
            rb.solverIterations = 8;
            rb.solverVelocityIterations = 8;
            rb.maxAngularVelocity = 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
