using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public Transform player; 
    public float distance = 5.0f; 
    public float height = 2.0f;
    public float angleCam = 30.0f; 

    private bool isThirdPerson = true;

    void Start()
    {
        firstPersonCamera.enabled = !isThirdPerson;
        thirdPersonCamera.enabled = isThirdPerson;
    }

    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.F))
        {
            isThirdPerson = !isThirdPerson;
            firstPersonCamera.enabled = !isThirdPerson;
            thirdPersonCamera.enabled = isThirdPerson;
        }

   
        if (isThirdPerson)
        {
            UpdateThirdPersonCamera();
        }
    }

    void UpdateThirdPersonCamera()
    {

        Vector3 cameraPosition = player.position - player.forward * distance + Vector3.up * height;

        thirdPersonCamera.transform.position = cameraPosition;

        Quaternion cameraRotation = Quaternion.Euler(angleCam, player.eulerAngles.y, 0);

        thirdPersonCamera.transform.rotation = cameraRotation;
    }
}