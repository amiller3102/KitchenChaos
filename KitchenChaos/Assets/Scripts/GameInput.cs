using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        /* When it gets to the ? if the OnInteractAction is not null it continues if it is null it stops
        which prevents an error. .Invoke is necessary because ? can not be followed by () but works 
        same way as calling a function */
        OnInteractAction?.Invoke(this, EventArgs.Empty);

        // the code below is the same as above but above is more compact
        /*if (OnInteractAction != null)
        {
            OnInteractAction(this, EventArgs.Empty);
        }*/
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
