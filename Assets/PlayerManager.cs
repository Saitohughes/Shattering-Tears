using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{
    PlayerInputManager inputManager;
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
    inputManager=GetComponent<PlayerInputManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {

            //inputManager.JoinPlayerFromActionIfNotAlreadyJoined();
        }
    }
}
