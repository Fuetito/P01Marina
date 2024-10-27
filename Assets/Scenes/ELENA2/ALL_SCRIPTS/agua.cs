using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agua : MonoBehaviour
{
    public float slowDownFactor = 0.5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movimiento movimiento = other.GetComponent<Movimiento>();
            if (movimiento != null)
            {
                movimiento.ModifySpeed(slowDownFactor); 
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
                movimiento.ResetSpeed(); 
            }
        }
    }
}

