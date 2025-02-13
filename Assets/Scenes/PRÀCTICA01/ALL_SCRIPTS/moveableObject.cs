using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveableObject : MonoBehaviour
{
    public float pushForce = 1;

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        Rigidbody rigg = hit.collider.attachedRigidbody;
        
        if(rigg != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position; 
                                                                                       
            forceDirection.y = 0; 
            forceDirection.Normalize(); 
                                        
                                      
            rigg.AddForceAtPosition(forceDirection * pushForce, transform.position,ForceMode.Impulse);

        }
    }


}
