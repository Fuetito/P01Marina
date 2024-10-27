using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion_mov : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Anim;
    public float WalkSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("Idle", true);
            transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.A)){
            Anim.SetBool("Idle", true);
            transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Anim.SetBool("Idle", true);
            transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Anim.SetBool("Idle", true);
            transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);
        }
        else
        {
            Anim.SetBool("Idle", false);
        }

    }
}
