using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Transform respawnPoint; // El punto inicial de reaparición

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Mueve al jugador al punto de reaparición
            other.transform.position = respawnPoint.position;
        }
    }


}
