using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overhead_camera : MonoBehaviour
{
    public Transform target; // Referencia al personaje
    public Vector3 offset = new Vector3(0, 20, 0); // Desplazamiento de la cámara

    void LateUpdate()
    {
        // Actualiza la posición de la cámara para que siga al personaje
        transform.position = target.position + offset;
    }
}