using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputController : MonoBehaviour
{
    
    Vector2 _move;
    public Vector2 Move => _move;

    public bool _jump;
    public bool Jump => _jump;
   
    private void OnMove(InputValue input)
    {
        _move = input.Get<Vector2>();
    }

    private void Update()
    {
        Debug.Log(Move);
    }
    private void OnJump()
    {
        _jump = true;
    }
}
