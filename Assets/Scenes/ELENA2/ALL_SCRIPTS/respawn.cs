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
            Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
            // Mueve al jugador al punto de reaparición
            other.transform.position = respawnPoint.position;

            // Reinicia la velocidad del jugador para evitar que mantenga el impulso
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
        }
    }


}
