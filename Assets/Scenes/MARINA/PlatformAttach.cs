using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    private Transform originalParent;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Store the player's original parent so we can reattach later
            originalParent = other.transform.parent;

            // Attach the player to the platform
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reattach the player to its original parent
            other.transform.SetParent(originalParent);
        }
    }
}
