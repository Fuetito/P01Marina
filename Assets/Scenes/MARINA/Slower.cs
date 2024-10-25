using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : MonoBehaviour
{
    Rigidbody _rigidbody;

    private float _orgDrag;
    private float _orgAngularDrag;

    public float AngularDragEffect = 10;
    public float DragEffect = 5;
    public float VelocityEffect = 0.5f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
    internal void SlowDown(float density)
    {
        _orgDrag = _rigidbody.drag; //nos guardamos los valores iniciales para después poder volver a darlos en el reset.
        _orgAngularDrag = _rigidbody.angularDrag;

        _rigidbody.velocity *= Mathf.Min(1, (VelocityEffect / density));
        _rigidbody.angularDrag = (AngularDragEffect * density);
        _rigidbody.drag = DragEffect * density;


    }

    internal void Reset()
    {
        _rigidbody.angularDrag = _orgAngularDrag;
        _rigidbody.drag = _orgDrag;
    }
}
