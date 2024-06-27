using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public InputActionAsset inputActions;
    public Button UpButton;
    public Button DownButton;
    public Button ResetButton;
    private InputAction Up;
    private InputAction Down;
    private InputAction Reset;
    public TMP_Text num;
    void Start()
    {
        var inputActionMap = inputActions.FindActionMap("KeyInput");
        Up = inputActionMap.FindAction("up");
        Down = inputActionMap.FindAction("down");
        Reset = inputActionMap.FindAction("reset");

        UpButton.onClick.AddListener(up);
        DownButton.onClick.AddListener(down);
        ResetButton.onClick.AddListener(reset);

        Up.performed += (InputAction.CallbackContext c) => UpButton.onClick.Invoke();
        Down.performed += (InputAction.CallbackContext c) => DownButton.onClick.Invoke();
        Reset.performed += (InputAction.CallbackContext c) => ResetButton.onClick.Invoke();

        Up.Enable();
        Down.Enable();
        Reset.Enable();
    }

    void up(){
        num.text = ((int.Parse(num.text))+1).ToString();
    }
    void down(){
        num.text = ((int.Parse(num.text))-1).ToString();
    }
    void reset(){
        num.text = 0.ToString();
    }

}
