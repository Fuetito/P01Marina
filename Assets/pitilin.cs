using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//MOVIMIENTO DEL PERSONAJE


public class pitilin : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController _characterController;
    InputController _input;
    GroundChecker _groundChecker;

    //VELOCITAT CAMINAR
    public float Speed = 1;
   public float JumpSpeed = 10;
    public float AirControl=10;

    //VELOCITAT ROTACI�
    public float TurnSpeed = 0.1f;
    private Vector3 _lastVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<InputController>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }
  
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var localInput = transform.right * _input.Move.x + transform.forward * _input.Move.y;
        Vector3 direction = new Vector3(localInput.x, 0, localInput.z);

        Vector3 vel = new Vector3();
        float smoothFactor = _groundChecker.Grounded ? 1 : AirControl * Time.deltaTime;

        vel.x = Mathf.Lerp(_lastVelocity.x, direction.x * Speed, smoothFactor);
        vel.y = _lastVelocity.y;
        vel.z = Mathf.Lerp(_lastVelocity.z, direction.z * Speed, smoothFactor);

        vel.y = GetGravity();

        _characterController.Move(vel * Time.deltaTime);

        _lastVelocity = vel;
    }
    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }







    /*
        private bool ShouldJump()
        {
            return _input.Jump && _groundChecker.Grounded;                 //SALTARRRR
        }

        private void Jump(ref Vector3 vel)
        {
            vel.y = JumpSpeed;
        }

        private void Move()
        {
            var localInput = transform.right * _input.Move.x + transform.forward * _input.Move.y;  //POV PLAYER
            //esto es simple move
            Vector3 direction = new Vector3(localInput.x, 0, localInput.z);
            //_characterController.SimpleMove(direction * Speed);

            Vector3 vel = new Vector3();
            float smoothFactor = _groundChecker.Grounded? 1 : AirControl * Time.deltaTime;


            vel.x = Mathf.Lerp(_lastVelocity.x, direction.x * Speed, smoothFactor);
            vel.y = _lastVelocity.y;
            vel.z = Mathf.Lerp(_lastVelocity.z, direction.z * Speed, smoothFactor);
            //not simple move

            vel.y = GetGravity();     //Aplicas una vel, guardas
            if (ShouldJump())                   //SALTARRCH
                Jump(ref vel);


            _characterController.Move(vel * Time.deltaTime);



            //turn around
            if (direction.magnitude > 0)
            {
                Vector3 target = transform.position + direction;
                Vector3 current = transform.position + transform.forward;
                Vector3 look = Vector3.Lerp(current, target, TurnSpeed * Time.deltaTime);

                transform.LookAt(target);

            }
            _lastVelocity = vel;      //la ultima vel del frame(?
        }

        private float GetGravity()
        {
            return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
        }*/

}
