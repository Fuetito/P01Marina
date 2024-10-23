using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public float Radius = 0.15f;
    private bool _grounded;
    public LayerMask WhatIsGround;

    public bool Grounded => _grounded;

    // Update is called once per frame
    void Update()
    {
        _grounded = Physics.CheckSphere(transform.position, Radius, WhatIsGround);

    }
}
