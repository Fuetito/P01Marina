using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal"));
        Debug.Log(Input.GetButton("Jump") + " hold");
        Debug.Log(Input.GetButtonDown("Jump") + " down");
        Debug.Log(Input.GetButtonUp("Jump") + "up");
    }
}
