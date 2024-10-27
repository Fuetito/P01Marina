using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDoble : MonoBehaviour
{
    public Transform PuertaIzq;
    public Transform PuertaDer;
    public float anguloApertura = -90f;
    public float velocidadApertura = 4f;
    private bool jugadorCerca = false;
    private bool puertasAbiertas = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            puertasAbiertas = !puertasAbiertas;
        }

        float anguloIzquierda = puertasAbiertas ? anguloApertura : 0;
        float anguloDerecha = puertasAbiertas ? -anguloApertura : 0;

        PuertaIzq.localRotation = Quaternion.Slerp(PuertaIzq.localRotation, Quaternion.Euler(0, anguloIzquierda, 0), Time.deltaTime * velocidadApertura);
        PuertaDer.localRotation = Quaternion.Slerp(PuertaDer.localRotation, Quaternion.Euler(0, anguloDerecha, 0), Time.deltaTime * velocidadApertura);
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