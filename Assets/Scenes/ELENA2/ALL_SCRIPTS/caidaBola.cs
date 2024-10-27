using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caidaBola : MonoBehaviour
{
    public Rigidbody bolaRigidbody;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bolaRigidbody.useGravity = true;
        }
    }
}
