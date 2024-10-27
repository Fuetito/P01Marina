using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaBalaninr : MonoBehaviour
{
    private Rigidbody platformRigidbody;

    void Start()
    {
        platformRigidbody = transform.parent.GetComponent<Rigidbody>(); // Obtiene el Rigidbody de la plataforma.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumenta la fuerza de la plataforma cuando el jugador pisa.
            platformRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Se puede agregar alguna lógica si deseas que ocurra algo al salir.
        }
    }
}




