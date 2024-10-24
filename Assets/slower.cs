using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slower : MonoBehaviour
{
    Rigidbody _rigidbody;

    private float _orgDrag;
    private float _orgAngularDrag;
    public float AngularDragEffect = 10; //Aquestes tres seguents es per a que tingui diferents pilotes a les que els hi afecti diferent el medi.
    public float DragEffect = 5;
    public float VelocityEffect = 0.5f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    internal void SlowDown(float density)
    {
        _orgDrag = _rigidbody.drag;
        _orgAngularDrag = _rigidbody.angularDrag;

        _rigidbody.velocity *= Mathf.Min(1, (VelocityEffect / density)); //Mathf.min per a que no passi d'1
        _rigidbody.angularDrag = (AngularDragEffect * density);
        _rigidbody.drag = DragEffect * density;
    }

    internal void Reset()
    {
        _rigidbody.angularDrag = _orgAngularDrag;
        _rigidbody.drag = _orgDrag;
    }
}
