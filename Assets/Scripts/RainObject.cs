using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RainObject : MonoBehaviour
{
    private bool _isOccupied;
    Rigidbody _myRig;
    Vector2 _originalPosition;
    public bool IsOccupied { get => _isOccupied; private set => _isOccupied = value; } 

    // Start is called before the first frame update
    void Start()
    {
        _myRig = GetComponent<Rigidbody>();
        _myRig.isKinematic = true;
        _originalPosition = new Vector3(1000,1000,1000); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveToRainPoint(Transform rainPoint)
    {
        transform.position = rainPoint.position;
        _myRig.isKinematic= false;
        _isOccupied= true;

        Invoke("ResetDrop", 4f);
    }

    public void ResetDrop()
    {
        Debug.Log("resetDrop");
        transform.position = _originalPosition;
        _myRig.isKinematic = true;
        _isOccupied = false;
    }
}
