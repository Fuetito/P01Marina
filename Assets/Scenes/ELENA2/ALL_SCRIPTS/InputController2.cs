using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController2 : MonoBehaviour
{
    private Vector2 _move;
    public Vector2 Move => _move;

    public bool _jump;

    public bool Jump => _jump;

    private bool _isRunning;
    public bool IsRunning => _isRunning;

    private void OnMove(InputValue input)
    {
        _move = input.Get<Vector2>();
    }

    private void OnJump()
    {
        _jump = true;

    }

    private void OnRun(InputValue input)
    {
        _isRunning = input.isPressed;
    }

    private void LateUpdate()
    {
        _jump = false;
    }
    private void Update()
    {
        _isRunning = Keyboard.current.rightShiftKey.isPressed;
        Debug.Log(Move);
    }
}