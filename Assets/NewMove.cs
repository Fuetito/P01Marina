using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMove : MonoBehaviour
{
    public float Speed = 2;

    Vector2 input;
    private void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    private void Update()
    {
        DoMove();
    }

    private void DoMove()
    {
        transform.Translate(input * Speed * Time.deltaTime);
    }
}
