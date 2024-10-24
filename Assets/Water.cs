using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float Density = 1;
    private void OnTriggerEnter(Collider other)
    {
        var Slower = other.GetComponent<slower>();     //el GetComponent mira de cualquier objeto.
        if (Slower != null)
        {
            Slower.SlowDown(Density);
        }
    }

    private void OnTriggerExit(Collider other)      //Cuando salga del agua
    {
        var Slower = other.GetComponent<slower>();
        if (Slower != null)
        {
            Slower.Reset();
        }
    }
}
