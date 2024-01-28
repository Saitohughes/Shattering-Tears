using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    private Mover mover;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<Mover>();
        int index = playerInput.playerIndex;
        mover = movers.FirstOrDefault(movers => movers.getPlayerIndex() == index);
    }

    // Update is called once per frame
    public void OnMove(InputAction.CallbackContext ctx) {

        if (mover != null) {

            mover.SetInputVector(ctx.ReadValue<Vector2>()); 
        
        }
        
    
    }

    
}
