using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Movimiento : MonoBehaviour
{
    CharacterController _characterController;
    InputController2 _input;

    public float Speed = 1;
    public float TurnSpeed = 5;
    public float JumpSpeed = 5;
    private Vector3 _lastVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<InputController2>();
    }

    // Update is called once per frame
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
        return _input.Jump; //TO TO replace with new input
    }

    private void Move()
    {
        var localInput = transform.right * _input.Move.x + transform.forward * _input.Move.y;
        Vector3 direction = new Vector3(localInput.x, 0, localInput.z); //La y es 0 para que solo se mueva horizontalmente, pero aun as� el
                                                                          //eje z tenemos y pq en InputController tenemos que coge un vector2, de manera que solo hay x e y
                                                                          //_characterController.SimpleMove(direction * Speed);   //Tiene en cuenta la gravedad de por si.

        Vector3 velocity = new Vector3();
        velocity.x = direction.x * Speed;
        velocity.y = _lastVelocity.y;
        velocity.z = direction.z * Speed;
        velocity.y = GetGravity();                  //Esta y la aterior  sirve para calcular la velocidad


        if (ShouldJump())               //El salto tiene que ser depsues de la gravedad, porque sino la sobreescribe
        {
            Jump(ref velocity);
        }

        _characterController.Move(velocity * Time.deltaTime);       //Esta para cambiar de posicion teniendo en cuenta la velocidad que emos calculado antes.



        //Turn
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
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }



}

