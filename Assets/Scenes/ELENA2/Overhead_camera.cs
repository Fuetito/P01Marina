using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overhead_camera : MonoBehaviour
{
    public Transform target; // Referencia al personaje
    public Vector3 offset = new Vector3(0, 20, 0); // Desplazamiento de la c�mara

    void LateUpdate()
    {
        // Actualiza la posici�n de la c�mara para que siga al personaje
        transform.position = target.position + offset;
    }
}