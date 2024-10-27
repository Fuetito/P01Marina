using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movimiento : MonoBehaviour
{
    CharacterController _characterController;
    InputController2 _input;
    Rigidbody rigidbody;

    public float Speed = 1;
    public float TurnSpeed = 2;
    public float JumpSpeed = 5;
    public float RunSpeed = 2;
    private Vector3 _lastVelocity;
    private float originalSpeed;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<InputController2>();
        originalSpeed = Speed;
    }


    void Update()
    {
        Move();
    }

    private void Jump(ref Vector3 velocity)
    {
        velocity.y = JumpSpeed;
    }
    private bool ShouldJump()
    {
        return _characterController.isGrounded && _input.Jump;

    }

    private void Move()
    {
        var localInput = transform.right * _input.Move.x + transform.forward * _input.Move.y;
        Vector3 direction = new Vector3(localInput.x, 0, localInput.z); 
                                                                       
        float currentSpeed = _input.IsRunning ? RunSpeed : Speed;

        Vector3 velocity = new Vector3();
        velocity.x = direction.x * currentSpeed;
        velocity.y = _lastVelocity.y;
        velocity.z = direction.z * currentSpeed;
        velocity.y = GetGravity();               


        if (ShouldJump())          
        {
            Jump(ref velocity);
        }

        _characterController.Move(velocity * Time.deltaTime);    



        if (direction.magnitude > 0)
        {
            Vector3 target = transform.position + direction;
            Vector3 current = transform.position + transform.forward;
            Vector3 look = Vector3.Lerp(current, target, TurnSpeed * Time.deltaTime);

            transform.LookAt(look);
        }
        _lastVelocity = velocity;
    }
    private float GetGravity()
    {
        return _characterController.isGrounded ? -0.1f : _lastVelocity.y + Physics.gravity.y * Time.deltaTime;

    }

    public void ModifySpeed(float factor)
    {
        Speed = originalSpeed * factor; 
    }

    public void ResetSpeed()
    {
        Speed = originalSpeed; 
    }

}