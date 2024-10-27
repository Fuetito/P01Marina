using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAffectPlayer : MonoBehaviour
{
    public float rotationSpeed = 30f;  // Rotation speed in degrees per second
    private Rigidbody playerRigidbody;

    void OnTriggerEnter(Collider other)
    {
        // Check if the player is on the platform
        if (other.CompareTag("Player"))
        {
            playerRigidbody = other.GetComponent<Rigidbody>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Stop affecting the player when they leave the platform
        if (other.CompareTag("Player"))
        {
            playerRigidbody = null;
        }
    }

    void FixedUpdate()
    {
        if (playerRigidbody != null)
        {
            // Calculate the angular velocity of the platform in radians per second
            float angularVelocity = rotationSpeed * Mathf.Deg2Rad;

            // Calculate the player's offset from the platform's center
            Vector3 offset = playerRigidbody.position - transform.position;

            // Calculate the tangential velocity based on angular velocity and offset
            Vector3 tangentialVelocity = Vector3.Cross(Vector3.up * angularVelocity, offset);

            // Apply this velocity to the player as if they're "carried" by the rotating platform
            playerRigidbody.velocity = tangentialVelocity;
        }
    }
}
