using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform puerta;
    public Vector3 posicionAbierta;
    public Vector3 posicionCerrada;
    public float velocidadApertura = 2f;
    private bool jugadorCerca = false;
    //private bool puertaAbierta = false;

    void Start()
    {
        posicionCerrada = puerta.localPosition;
    }

    void Update()
    {
        if (jugadorCerca)
        {
            puerta.localPosition = Vector3.Lerp(puerta.localPosition, posicionAbierta, Time.deltaTime * velocidadApertura);
        }
        else
        {
            puerta.localPosition = Vector3.Lerp(puerta.localPosition, posicionCerrada, Time.deltaTime * velocidadApertura);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}