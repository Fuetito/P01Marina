using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check de q el player entre en la plataforma
        if (other.CompareTag("Player"))
        {
            // Set plataforma como padre del player
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check de que el player salga de la plataforma
        if (other.CompareTag("Player"))
        {
            // Quitar player de ser hijo de la plataforma
            other.transform.SetParent(null);
        }
    }
}
