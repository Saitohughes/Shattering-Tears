using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 3f;  
    
    [SerializeField]
    private int playerIndex = 0;

    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public int getPlayerIndex()
    {
        return playerIndex;
    }
    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    private void Update()
    {
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
