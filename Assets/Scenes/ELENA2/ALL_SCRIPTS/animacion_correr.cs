using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion_correr : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Anim;
    public float WalkSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            Anim.SetBool("correr", true);
            transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);

        }
        else
        {
            Anim.SetBool("correr", false);
        }

    }
}
