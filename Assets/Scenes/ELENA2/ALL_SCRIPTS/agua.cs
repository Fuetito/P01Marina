using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agua : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Factor de desaceleración

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movimiento movimiento = other.GetComponent<Movimiento>();
            if (movimiento != null)
            {
                movimiento.ModifySpeed(slowDownFactor); // Reduce la velocidad del jugador
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movimiento movimiento = other.GetComponent<Movimiento>();
            if (movimiento != null)
            {
                movimiento.ResetSpeed(); // Restaura la velocidad del jugador
            }
        }
    }
}

