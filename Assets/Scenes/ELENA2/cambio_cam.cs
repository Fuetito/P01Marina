using System.Collections;
using System.Collections.Generic;
/*using UnityEngine;

public class cambio_cam : MonoBehaviour
{

    public bool tPerson = true;
    [Header("Objetivos de c�mara")]
    public Transform tpTarget;
    public Transform fpTarget;
    [Header("Visibilidad de Jugador")]
    public bool disablePlayerMesh = true;
    [Space(2)]
    public GameObject playerMesh;
    [Space(5)]
    private Vector2 angle = new Vector2(90* Mathf.Deg2Rad, 0);
    private new Camera camera;
    private Vector2 nearPlaneSize;
    private Transform follow;
    private float defaultDistance;
    private float newDistance;
//Distancias camara
*//*    public float maxDistace = 20.0f;
*//*    public float minDistance = 10.0f;
    public float height = 10f.0;
    public float angleCam = 45.0;

    [Space(6)]

    [Header("Tecla para cambiar perspectiva")]
    public KeyCode keyCode = KeyCode.Q;

    // Start is called before the first frame update
    void Start()
    {

        ChangePerspective(tPerson);


        *//*defaultDistance = (maxDistace + minDistance) / 2;
        newDistance = defaultDistance;*//*
        newDistance = minDistance;
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponent<Camera>();

    }

    void ChangePerspective(bool ThirdPerson)
    {
        if (ThirdPerson)
        {
            follow = tpTarget;

            if (disablePlayerMesh)
                playerMesh.SetActive(true);


            tPerson = true;
        }
        else if(!ThirdPerson)
        {
            follow = fpTarget;

            if(disablePlayerMesh)
            playerMesh.SetActive(false);


            tPerson = false;


        }

    }

    private void CalculateNearPlaneSize()
    {
        float height = Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2) * camera.nearClipPlane;
        float width = height * camera.aspect;

        nearPlaneSize = new Vector2(width, height);
    }

    private Vector3[] GetCameraCollisionPoints(Vector3 direction)
    {
        Vector3 position = follow.position;
        Vector3 center = position + direction * (camera.nearClipPlane + 0.4f);

        Vector3 right = transform.right * nearPlaneSize.x;
        Vector3 up = transform.up * nearPlaneSize.y;

        return new Vector3[]
        {
            center - right + up,
            center + right + up,
            center - right - up,
            center + right - up
        };
    }

    void Update()
    {


        if (Input.GetKeyDown(keyCode))
        {
            if (tPerson)
                ChangePerspective(false);
            else
                ChangePerspective(true);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = new Vector3(
            Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
            -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)
            );

        RaycastHit hit;
        float distance = defaultDistance;
        Vector3[] points = GetCameraCollisionPoints(direction);

        foreach (Vector3 point in points)
        {
            if (Physics.Raycast(point, direction, out hit, defaultDistance))
            {
                distance = Mathf.Min((hit.point - follow.position).magnitude, distance);
            }
        }

        transform.position = follow.position + direction * distance;
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }
}
*/
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public Transform player; // Referencia al jugador para seguir su posici�n
    public float distance = 5.0f; // Distancia de la c�mara en tercera persona
    public float height = 2.0f; // Altura de la c�mara en tercera persona
    public float angleCam = 30.0f; // �ngulo de la c�mara en tercera persona

    private bool isThirdPerson = true;

    void Start()
    {
        // Inicializa las c�maras
        firstPersonCamera.enabled = !isThirdPerson;
        thirdPersonCamera.enabled = isThirdPerson;
    }

    void Update()
    {
        // Cambia de c�mara con la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            isThirdPerson = !isThirdPerson;
            firstPersonCamera.enabled = !isThirdPerson;
            thirdPersonCamera.enabled = isThirdPerson;
        }

        // Actualiza la posici�n y rotaci�n de la c�mara en tercera persona
        if (isThirdPerson)
        {
            UpdateThirdPersonCamera();
        }
    }

    void UpdateThirdPersonCamera()
    {
        // Calcula la posici�n deseada de la c�mara en tercera persona
        Vector3 cameraPosition = player.position - player.forward * distance + Vector3.up * height;

        // Aplica la posici�n calculada a la c�mara
        thirdPersonCamera.transform.position = cameraPosition;

        // Calcula la rotaci�n deseada de la c�mara
        Quaternion cameraRotation = Quaternion.Euler(angleCam, player.eulerAngles.y, 0);

        // Aplica la rotaci�n calculada a la c�mara
        thirdPersonCamera.transform.rotation = cameraRotation;
    }
}