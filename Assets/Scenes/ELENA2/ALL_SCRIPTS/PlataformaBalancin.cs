using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaBalaninr : MonoBehaviour
{
    private Rigidbody platformRigidbody;

    void Start()
    {
        platformRigidbody = transform.parent.GetComponent<Rigidbody>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            platformRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}




