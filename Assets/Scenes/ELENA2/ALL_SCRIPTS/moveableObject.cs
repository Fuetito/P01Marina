using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveableObject : MonoBehaviour
{
    public float pushForce = 1;

    private void OnControllerColliderHit(ControllerColliderHit hit) //va a detectar cuando el charachter controller empuja algo. Hit representa el objeto que es golpeado
    {
        Rigidbody rigg = hit.collider.attachedRigidbody;
        
        if(rigg != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position; //restamos la posici�n del cubo a la del personaje 
                                                                                             //(personaje - cubo) para que nos de la direcci�n de d�nde viene la fuerza
            forceDirection.y = 0; //no queremos que la y cambie de posici�n, solo queremos que se mueva en x z
            forceDirection.Normalize(); //esto es para normalizar el vector. Hace que el vector resultante 
                                        // apunte en la misma direcci�n pero hace que la longitud sea 1
                                        //Lo usamos porque s�lo queremos saber la direcci�n en que algo se mueve, y no la distancia
            rigg.AddForceAtPosition(forceDirection * pushForce, transform.position,ForceMode.Impulse);
            //Add Force at positoin necesita un vector3 de fuerza, vector3 de posicion y tambi�n se le puede a�adir la manera
            //en la que aplicamos la fuerza
        }
    }


}
