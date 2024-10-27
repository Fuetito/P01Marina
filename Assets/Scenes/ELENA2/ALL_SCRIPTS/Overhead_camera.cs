using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overhead_camera : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 20, 0); 

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}