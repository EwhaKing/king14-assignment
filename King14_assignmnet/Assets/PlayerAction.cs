using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    MainInputAction action;
    InputAction moveAction;

    private void Awake()
    {
        action = new MainInputAction();
        moveAction = action.Player.Move;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        moveAction.started += Started;
        moveAction.performed += Performed;
        moveAction.canceled += Canceled;
    }

    private void FixedUpdate()
    {
        Vector2 keyboard_vector = moveAction.ReadValue<Vector2>();
        MOVE(keyboard_vector.x, keyboard_vector.y);
    }

    private void OnDisable()
    {
        moveAction.Disable();
        moveAction.started -= Started;
        moveAction.performed -= Performed;
        moveAction.canceled -= Canceled;
    }

    void Started(InputAction.CallbackContext context)
    {
        Debug.Log("started!");
    }

    void Performed(InputAction.CallbackContext context)
    {
        Debug.Log("performed!");
    }

    void Canceled(InputAction.CallbackContext context)
    {
        Debug.Log("canceled!");
    }

    void MOVE(float _x, float _y)
    {
        this.transform.position = new Vector2(this.transform.position.x + _x, this.transform.position.y + _y);
    }
}
