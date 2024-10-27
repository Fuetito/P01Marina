using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotationSpeed = 30f;

    void Update()
    {
        // Rotar plataforma sobre el eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
